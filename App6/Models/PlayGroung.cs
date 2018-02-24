using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace App6.Models
{
    public class PlayGround
    {
        public static Models.Chess currentMovingFigure = null;
        public delegate void HighLightHandler(object sender, RoutedEventArgs e, Location location, bool press = true);
        public enum Actions { pressed, inFocus};

        private Grid mainWindow;
        //collection of all figures on the desk
        private static List<Chess> _figures;
        public static List<Models.Chess> figures
        {
            get
            {
                return _figures;
            }
        }
        //collection of all cells on the desk
        private List<Models.Cell> cells;
        //shows which team is moving at the moment
        public static Chess.Team MovingTeam = Chess.Team.white;
       

        //constructor
        public PlayGround(Grid mainWindow)
        {
            _figures = new List<Chess>();
            cells = new List<Models.Cell>();
            this.mainWindow = mainWindow;
        }
        public static Grid playGround = new Grid();
        private Location GetLocation(object sender)
        {
            return new Location() { row = Grid.GetRow(sender as FrameworkElement), column = Grid.GetColumn(sender as FrameworkElement) };
        }
        
        // changing cell`s colour to red(pressed mode) and back
        private void HighLightCell(object sender, RoutedEventArgs e, Location locationOfTheFigure, bool press = true)
        {
            //finding cell which must be highlighted
            var cell = cells.Find(x => x.location == locationOfTheFigure);
            //if value of "press" field is true it will be highlighted , otherwise - unreleased
            if (press)
            {
                Viewes.Cell.ChangeColor(cell, Cell.Types.pressed);
            }
            else
            {
                //changes cell`s fill to it`s natural colour
                Viewes.Cell.ChangeColor(cell, cell.type);
            }
        }
        // shows is the game solved or not
        public bool IsTheGameSolved()
        {
            return true;
        }
        //Models back
        private void FocusCell(object sender, RoutedEventArgs e)
        {
            Handlers.Cell.ChangeFocus(cells.Find(x=>x.location == GetLocation(sender)));
        }
        private void ClickCell(object sender, RoutedEventArgs e)
        {
            Handlers.PlayGroung.Click(sender, e, GetLocation(sender), Models.PlayGround.figures, ref Models.PlayGround.MovingTeam, Models.PlayGround.TeamMoving);
        }
        private void DisFocusCell(object sender, RoutedEventArgs e)
        {
            Handlers.Cell.ChangeFocus(cells.Find(x => x.location == GetLocation(sender)), false);
        }
        private void PressCell(object sender, RoutedEventArgs e)
        {
            Handlers.Cell.Pressed(cells.Find(x => x.location == GetLocation(sender)));
        }
        public void InitializeEvents()
        {
            foreach(Cell cell in cells)
            {
                cell.rectangle.PointerPressed += ClickCell;
                cell.rectangle.PointerEntered += FocusCell;
                cell.rectangle.PointerExited += DisFocusCell;
                //cell.rectangle.PointerPressed += PressCell;
            }
        }
        // a label dispaying MovingTeam`s value
        public static TextBlock TeamMoving = new TextBlock();
        // all processes which must be done during grid initialization
        public void InitializeGrid()
        {
            //making a playground Grid
            
            playGround.Height = 630;
            playGround.Width = 630;
            //playGround.BorderBrush = new SolidColorBrush(Windows.UI.Colors.DarkOliveGreen); 
            //playGround.BorderThickness = new Thickness(5);
            //initializing label and adding it to the mainwindow
            TeamMoving.Text = MovingTeam.ToString();
            TeamMoving.TextAlignment = TextAlignment.Left;
            TeamMoving.HorizontalAlignment = HorizontalAlignment.Left;
            TeamMoving.VerticalAlignment = VerticalAlignment.Center;
            this.mainWindow.Children.Add(TeamMoving);
            //adding playground grid to the mainwindow
            this.mainWindow.Children.Add(playGround);
            //a cycle which adds white and black cells to the playground,making it a chess desk
            for (int i = 0; i < 8; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength((playGround.Height) / 9);
                playGround.RowDefinitions.Add(row);
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength((playGround.Height) / 9);
                playGround.ColumnDefinitions.Add(column);
                //cell`s colour depends on it`s possition
                for (int j = 0; j < 8; j++)
                {
                    Models.Cell.Types type;
                    if ((i + j) % 2 == 1)
                    {
                        type = Models.Cell.Types.black;
                    }
                    else
                    {
                        type = Models.Cell.Types.white;
                    }
                    Models.Cell rectangle = new Models.Cell(type, new Location { row = i, column = j });
                    cells.Add(rectangle);
                    rectangle.Locate(playGround);
                }

            }
            // adding all figures to the desk
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 1)
                    {
                        Location location = new Location() { column = j, row = i };
                        PlayGround.figures.Add(new Pawn(Models.Chess.Team.white, HighLightCell, location));
                    }
                    else if (i == 6)
                    {
                        Location location = new Location() { column = j, row = i };
                        PlayGround.figures.Add(new Pawn(Models.Chess.Team.black, HighLightCell, location));
                    }
                }
            }


            // White king
            PlayGround.figures.Add(new King(Models.Chess.Team.white, HighLightCell));
            // Black king
            PlayGround.figures.Add(new King(Models.Chess.Team.black, HighLightCell));
            // White queen
            PlayGround.figures.Add(new Queen(Models.Chess.Team.white, HighLightCell));
            // Black queen
            PlayGround.figures.Add(new Queen(Models.Chess.Team.black, HighLightCell));
            // White bishops
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.white, HighLightCell,true));
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.white, HighLightCell));
            // Black bishops
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.black, HighLightCell,true));
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.black, HighLightCell));
            // White knights           
            PlayGround.figures.Add(new Knight(Models.Chess.Team.white, HighLightCell,true));
            PlayGround.figures.Add(new Knight(Models.Chess.Team.white, HighLightCell));
            // Black knights
            PlayGround.figures.Add(new Knight(Models.Chess.Team.black, HighLightCell,true));
            PlayGround.figures.Add(new Knight(Models.Chess.Team.black, HighLightCell));
            // White rooks
            PlayGround.figures.Add(new Rook(Models.Chess.Team.white, HighLightCell,true));
            PlayGround.figures.Add(new Rook(Models.Chess.Team.white, HighLightCell));
            // Black rooks
            PlayGround.figures.Add(new Rook(Models.Chess.Team.black, HighLightCell,true));
            PlayGround.figures.Add(new Rook(Models.Chess.Team.black, HighLightCell));
            foreach (Chess figure in figures)
            {
                Viewes.PlayGround.Add(Models.PlayGround.playGround, figure);
                Viewes.PlayGround.Locate(figure);
            }
            playGround.VerticalAlignment = VerticalAlignment.Center;
            playGround.HorizontalAlignment = HorizontalAlignment.Center;

        }
    }
}
        
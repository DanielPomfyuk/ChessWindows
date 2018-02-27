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
        public  Models.Chess currentMovingFigure = null;
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
        public  Chess.Team MovingTeam = Chess.Team.white;
        //constructor
        public PlayGround(Grid mainWindow)
        {
            _figures = new List<Chess>();
            cells = new List<Models.Cell>();
            this.mainWindow = mainWindow;
        }
        public  Grid playGround = new Grid();
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
        public void Move(object sendingFigure, RoutedEventArgs e, Models.Location location, Models.Chess currentMovingFigure, List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        {
            // checking is there any movin figure on the desk
            if (currentMovingFigure != null)
            {
                if (currentMovingFigure is Models.King && Math.Abs(location.column - (currentMovingFigure as King).position.column) == 2)
                {
                    Castling(sendingFigure, e, currentMovingFigure as King, location, figures, ref MovingTeam, TeamMovingIndicator);
                }
                // checking can the figure stand on current cell
                else if (currentMovingFigure.IsTheMovePossible(location, figures))
                {
                    // unreleasing figure`s cell and moving her to the new place
                    HighLightCell(sendingFigure, e, currentMovingFigure.position, false);
                    MoveFigure(currentMovingFigure, location, figures, ref MovingTeam, TeamMovingIndicator);
                }
                // if move is not possible player will see a messege
                else
                {
                    Viewes.PlayGround.MoveNotPossibleMessege();
                }
                // changing current moving figure`s value to null
                HighLightCell(sendingFigure, e, currentMovingFigure.position, false);
                currentMovingFigure = null;
            }
        }
        public  void Castling(object sendingFigure, RoutedEventArgs e, King king, Location location, List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        {
            if (king.isItTheFirstMove)
            {
                int rookOriginalColumn;
                int rookFinalColumn;
                int kingFinalColumn;
                if (location.column > king.position.column)
                {
                    rookOriginalColumn = 7;
                    rookFinalColumn = 5;
                    kingFinalColumn = 6;
                    location.column--;
                }
                else
                {
                    rookOriginalColumn = 0;
                    rookFinalColumn = 3;
                    kingFinalColumn = 2;
                    location.column++;
                }
                var rook = figures.Find(x => x is Rook && x.position.column == rookOriginalColumn && x.team == king.team && ((Rook)(x)).isItTheFirstMove == true);
                if (rook != null && rook.IsTheMovePossible(location, figures))
                {
                    HighLightCell(sendingFigure, e, king.position, false);
                    rook.position = new Location { column = rookFinalColumn, row = rook.position.row };
                    king.position = new Location { column = kingFinalColumn, row = king.position.row };
                    Viewes.PlayGround.Locate(rook);
                    Viewes.PlayGround.Locate(king);
                    MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
                    Viewes.PlayGround.MovingTeamSwitcher(TeamMovingIndicator, MovingTeam.ToString());
                }
            }
        }

        public  void Click(object sender, RoutedEventArgs e, Location location, List<Models.Chess> figures, ref Chess.Team MovingTeam, TextBlock MovingTeamIndicator)
        {
            // checking is there any movin figure on the desk
            if (currentMovingFigure != null)
            {
                if (currentMovingFigure is Models.King && Math.Abs(location.column - ((King)(currentMovingFigure)).position.column) == 2)
                {
                    Castling(sender, e, (King)(currentMovingFigure), location, figures, ref MovingTeam, MovingTeamIndicator);
                }
                // checking can the figure stand on current cell
                else if (currentMovingFigure.IsTheMovePossible(location, figures))
                {
                    // unreleasing figure`s cell and moving her to the new place
                    HighLightCell(sender, e, currentMovingFigure.position, false);
                    Move(sender, e, location, currentMovingFigure, figures, ref MovingTeam, TeamMoving);
                }
                // if move is not possible player will see a messege
                else
                {
                    Viewes.PlayGround.MoveNotPossibleMessege();
                }
                // changing current moving figure`s value to null
                HighLightCell(sender, e, currentMovingFigure.position, false);
                currentMovingFigure = null;
            }
        }

        public  void MoveHandler(object sender, RoutedEventArgs e, Chess figure, List<Models.Chess> figures)
        {
            if (currentMovingFigure == null)
            {
                if (figure.team == MovingTeam)
                {
                    currentMovingFigure = figure;
                    HighLightCell(sender, e, figure.position);
                }
            }
            else
            {
                int y = Grid.GetColumn((FrameworkElement)sender);
                int x = Grid.GetRow((FrameworkElement)sender);
                Models.Location position1 = new Location() { row = x, column = y };
                if (currentMovingFigure.IsTheMovePossible(figure.position, figures))
                {
                    HighLightCell(sender, e, currentMovingFigure.position, false);
                    Move(sender, e, position1, currentMovingFigure, figures, ref MovingTeam, TeamMoving);
                }
                else
                {
                    Viewes.PlayGround.MoveNotPossibleMessege();
                }
                HighLightCell(sender, e, currentMovingFigure.position, false);
                currentMovingFigure = null;
            }
        }
        //Models back
        public  void ChangeFocus(Models.Cell cell, bool focused = true)
        {
            //moving figure stands on current cell nothing will happen
            if (currentMovingFigure != null && currentMovingFigure.position == cell.location)
            {

            }
            else
            {
                //otherwise cell`s fill will change to focused or native  colour
                if (focused)
                {
                    Viewes.Cell.ChangeColor(cell, Models.Cell.Types.focused);
                }
                else
                {
                    Viewes.Cell.ChangeColor(cell, cell.type);
                }
            }
        }
        private void FocusCell(object sender, RoutedEventArgs e)
        {
            ChangeFocus(cells.Find(x=>x.location == GetLocation(sender)));
        }
        private void ClickCell(object sender, RoutedEventArgs e)
        {
            Click(sender, e, GetLocation(sender), Models.PlayGround.figures, ref MovingTeam, Models.PlayGround.TeamMoving);
        }
        private void DisFocusCell(object sender, RoutedEventArgs e)
        {
            ChangeFocus(cells.Find(x => x.location == GetLocation(sender)), false);
        }
        private void ChessMove(object sender , RoutedEventArgs e)
        {
           MoveHandler(sender, e, figures.Find(x => x.position == GetLocation(sender)), figures);
        }
        public void InitializeEvents()
        {
            foreach(Cell cell in cells)
            {
                cell.rectangle.PointerPressed += ClickCell;
                cell.rectangle.PointerEntered += FocusCell;
                cell.rectangle.PointerExited += DisFocusCell;
            }
            foreach(Chess figure in figures)
            {
                figure.gridControlElement.PointerPressed += ChessMove;
            }
        }
        public  void MoveFigure(Models.Chess figure, Location newLocation, List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        {
            //if the move will produce a check for figures team move will be canceled
            if (WillResultWithCheck(figure, newLocation, figures))
            {
                Viewes.PlayGround.PotentialCheckMessege();
                return;
            }
            // checking if there is an enemy on the chosen cell
            Models.Chess enemy = figures.Find(x => x.position == newLocation);
            // if there is an enemy , it will be removed from the desk and figures collection
            if (enemy != null)
            {
                figures.Remove(enemy);
                Viewes.PlayGround.Remove(playGround, enemy);
            }
            //setting figures new position
            figure.position = newLocation;
            Viewes.PlayGround.Locate(figure);

            //after the move MovingTeam and Label`s values should  be changed to  oposite team
            MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
            // if team has check game will show a messege to the player
            if (IsATeamChecked(MovingTeam, figures))
            {
                if (IsItAMate(MovingTeam, figures))
                {
                    Windows.UI.Popups.MessageDialog lose = new Windows.UI.Popups.MessageDialog("You lost,{0}", MovingTeam.ToString());
                    lose.ShowAsync();
                }
                else
                {
                    Windows.UI.Popups.MessageDialog teamChecked = new Windows.UI.Popups.MessageDialog("Ops,you`re checked :(");
                    teamChecked.ShowAsync();
                }
            }
            Viewes.PlayGround.MovingTeamSwitcher(TeamMovingIndicator, MovingTeam.ToString());
        }
        private  bool IsATeamChecked(Models.Chess.Team team, List<Models.Chess> figures)
        {
            // finds team`s king
            Models.Chess king = figures.Find(x => x.team == team && x is King);
            foreach (Models.Chess figure in figures)
            {
                // if enemy can get to team`s king it means team has check
                if (figure.team != team && figure.IsTheMovePossible(king.position, figures))
                {
                    return true;
                }
            }
            return false;
        }
        // checkes will current move produse cheack for team or not
        private  bool WillResultWithCheck(Models.Chess movingFigure, Location destination, List<Models.Chess> figures)
        {
            // simulating a clone list of figures collection with changing cordinates for moving figure
            List<Models.Chess> simulated = new List<Models.Chess>();
            foreach (Models.Chess figure in figures)
            {
                if (figure.position == destination)
                {
                    continue;
                }
                var clonedFigure = figure.clone();
                if (figure == movingFigure)
                {
                    clonedFigure.position = destination;
                }
                simulated.Add(clonedFigure);
            }
            // checking if team with new location has check
            return IsATeamChecked(movingFigure.team, simulated);
        }
        private  bool IsItAMate(Models.Chess.Team team, List<Models.Chess> figures)
        {
            foreach (Models.Chess figure in figures.FindAll(x => x.team == team))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Location candidate = new Location { row = i, column = j };
                        if (figure.IsTheMovePossible(candidate, figures) && !WillResultWithCheck(figure, candidate, figures))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
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
                        PlayGround.figures.Add(new Pawn(Models.Chess.Team.white, location));
                    }
                    else if (i == 6)
                    {
                        Location location = new Location() { column = j, row = i };
                        PlayGround.figures.Add(new Pawn(Models.Chess.Team.black, location));
                    }
                }
            }


            // White king
            PlayGround.figures.Add(new King(Models.Chess.Team.white));
            // Black king
            PlayGround.figures.Add(new King(Models.Chess.Team.black));
            // White queen
            PlayGround.figures.Add(new Queen(Models.Chess.Team.white));
            // Black queen
            PlayGround.figures.Add(new Queen(Models.Chess.Team.black));
            // White bishops
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.white,true));
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.white));
            // Black bishops
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.black,true));
            PlayGround.figures.Add(new Bishop(Models.Chess.Team.black));
            // White knights           
            PlayGround.figures.Add(new Knight(Models.Chess.Team.white,true));
            PlayGround.figures.Add(new Knight(Models.Chess.Team.white));
            // Black knights
            PlayGround.figures.Add(new Knight(Models.Chess.Team.black,true));
            PlayGround.figures.Add(new Knight(Models.Chess.Team.black));
            // White rooks
            PlayGround.figures.Add(new Rook(Models.Chess.Team.white,true));
            PlayGround.figures.Add(new Rook(Models.Chess.Team.white));
            // Black rooks
            PlayGround.figures.Add(new Rook(Models.Chess.Team.black,true));
            PlayGround.figures.Add(new Rook(Models.Chess.Team.black));
            foreach (Chess figure in figures)
            {
                Viewes.PlayGround.Add(playGround, figure);
                Viewes.PlayGround.Locate(figure);
            }
            playGround.VerticalAlignment = VerticalAlignment.Center;
            playGround.HorizontalAlignment = HorizontalAlignment.Center;

        }
    }
}
        
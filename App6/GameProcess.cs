using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using App6.Models;

namespace App6
{
    //class PlayGround
    //{
    //    public static Models.Chess currentMovingFigure = null;
    //    public delegate void HighLightHandler(object sender, RoutedEventArgs e, Location location, bool press = true);

    //    private Grid mainWindow;
    //    //collection of all figures on the desk
    //    public static List<Chess> figures;
    //    //collection of all cells on the desk
    //    private List<Models.Cell> cells;
    //    //shows which team is moving at the moment
    //    public static Chess.Team MovingTeam = Chess.Team.white;
    //    //constructor
    //    public PlayGround(Grid mainWindow)
    //    {
    //        figures = new List<Chess>();
    //        cells = new List<Models.Cell>();
    //        this.mainWindow = mainWindow;
    //    }
    //    // changing cell`s colour to red(pressed mode) and back
    //    private void HighLightCell(object sender, RoutedEventArgs e, Location locationOfTheFigure, bool press = true)
    //    {
    //        //finding cell which must be highlighted
    //        var cell = cells.Find(x => x.location == locationOfTheFigure);
    //        //if value of "press" field is true it will be highlighted , otherwise - unreleased
    //        if (press)
    //        {
    //            cell.Pressed(sender, e);
    //        }
    //        else
    //        {
    //            cell.Unrelease();
    //        }
    //    }
    //    // shows is the game solved or not
    //    public bool IsTheGameSolved()
    //    {
    //        return true;
    //    }
    //    // a label dispaying MovingTeam`s value
    //    static TextBlock TeamMoving = new TextBlock();
    //    // all processes which must be done during grid initialization
    //    public void InitializeGrid()
    //    {
    //        //making a playground Grid
    //        Grid playGround = new Grid();
    //        playGround.Height = 630;
    //        playGround.Width = 630;
    //        //playGround.BorderBrush = new SolidColorBrush(Windows.UI.Colors.DarkOliveGreen); 
    //        //playGround.BorderThickness = new Thickness(5);
    //        //initializing label and adding it to the mainwindow
    //        TeamMoving.Text = MovingTeam.ToString();
    //        TeamMoving.TextAlignment = TextAlignment.Left;
    //        TeamMoving.HorizontalAlignment = HorizontalAlignment.Left;
    //        TeamMoving.VerticalAlignment = VerticalAlignment.Center;
    //        this.mainWindow.Children.Add(TeamMoving);
    //        //adding playground grid to the mainwindow
    //        this.mainWindow.Children.Add(playGround);
    //        //a cycle which adds white and black cells to the playground,making it a chess desk
    //        for (int i = 0; i < 8; i++)
    //        {
    //            RowDefinition row = new RowDefinition();
    //            row.Height = new GridLength((playGround.Height) / 9);
    //            playGround.RowDefinitions.Add(row);
    //            ColumnDefinition column = new ColumnDefinition();
    //            column.Width = new GridLength((playGround.Height) / 9);
    //            playGround.ColumnDefinitions.Add(column);
    //            //cell`s colour depends on it`s possition
    //            for (int j = 0; j < 8; j++)
    //            {
    //                Models.Cell.Types type;
    //                if ((i + j) % 2 == 1)
    //                {
    //                    type = Models.Cell.Types.black;
    //                }
    //                else
    //                {
    //                    type = Models.Cell.Types.white;
    //                }
    //                Models.Cell rectangle = new Models.Cell(type, new Location { row = i, column = j }, playGround);
    //                cells.Add(rectangle);
    //                rectangle.Locate();
    //            }

    //        }
    //        // adding all figures to the desk
    //        for (int i = 0; i < 8; i++)
    //        {
    //            for (int j = 0; j < 8; j++)
    //            {
    //                if (i == 1 || i == 6)
    //                {
    //                    Image pawn = new Image();

    //                    BitmapImage bmp = (i == 1) ? new BitmapImage(new Uri("ms-appx:///Assets/whitePawn.png")) : new BitmapImage(new Uri("ms-appx:///Assets/blackPawn.png"));
    //                    pawn.Source = bmp;
    //                    pawn.HorizontalAlignment = HorizontalAlignment.Center;
    //                    pawn.VerticalAlignment = VerticalAlignment.Center;
    //                    Chess.Team team = (i == 1) ? Chess.Team.white : Chess.Team.black;
    //                    PlayGround.figures.Add(new Pawn(pawn, new Location() { row = i, column = j }, team, playGround, HighLightCell));
    //                }
    //            }
    //        }


    //        // White king
    //        Image queen = new Image();
    //        BitmapImage bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteKing.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new King(queen, new Location() { row = 0, column = 4 }, Chess.Team.white, playGround, HighLightCell));
    //        // Black king
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackKing.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new King(queen, new Location() { row = 7, column = 4 }, Chess.Team.black, playGround, HighLightCell));
    //        // White queen
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteQueenNew.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Queen(queen, new Location() { row = 0, column = 3 }, Chess.Team.white, playGround, HighLightCell));
    //        // Black queen
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackQueenNew.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Queen(queen, new Location() { row = 7, column = 3 }, Chess.Team.black, playGround, HighLightCell));
    //        // White bishops
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteBishop.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Bishop(queen, new Location() { row = 0, column = 2 }, Chess.Team.white, playGround, HighLightCell));
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteBishop.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Bishop(queen, new Location() { row = 0, column = 5 }, Chess.Team.white, playGround, HighLightCell));
    //        // Black bishops
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackBishop.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Bishop(queen, new Location() { row = 7, column = 2 }, Chess.Team.black, playGround, HighLightCell));
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackBishop.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Bishop(queen, new Location() { row = 7, column = 5 }, Chess.Team.black, playGround, HighLightCell));
    //        // White knights
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteKnight.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Knight(queen, new Location() { row = 0, column = 1 }, Chess.Team.white, playGround, HighLightCell));
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteKnight.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Knight(queen, new Location() { row = 0, column = 6 }, Chess.Team.white, playGround, HighLightCell));
    //        // Black knights
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackKnight.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Knight(queen, new Location() { row = 7, column = 1 }, Chess.Team.black, playGround, HighLightCell));
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackKnight.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Knight(queen, new Location() { row = 7, column = 6 }, Chess.Team.black, playGround, HighLightCell));
    //        // White rooks
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteRook.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Rook(queen, new Location() { row = 0, column = 0 }, Chess.Team.white, playGround, HighLightCell));
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteRook.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Rook(queen, new Location() { row = 0, column = 7 }, Chess.Team.white, playGround, HighLightCell));
    //        // Black rooks
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackRook.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Rook(queen, new Location() { row = 7, column = 0 }, Chess.Team.black, playGround, HighLightCell));
    //        queen = new Image();
    //        bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackRook.png"));
    //        queen.Source = bmw;
    //        queen.HorizontalAlignment = HorizontalAlignment.Center;
    //        queen.VerticalAlignment = VerticalAlignment.Center;
    //        PlayGround.figures.Add(new Rook(queen, new Location() { row = 7, column = 7 }, Chess.Team.black, playGround, HighLightCell));
    //        foreach (Chess figure in figures)
    //        {
    //            figure.Locate();
    //        }
    //        playGround.VerticalAlignment = VerticalAlignment.Center;
    //        playGround.HorizontalAlignment = HorizontalAlignment.Center;
    //    }
    //    // moves figure from one cell to another if it`s posible
    //    public static void MoveFigure(Chess figure, Location newLocation)
    //    {
    //        //if the move will produce a check for figures team move will be canceled
    //        if (WillResultWithCheck(figure, newLocation))
    //        {
    //            Windows.UI.Popups.MessageDialog checkmessege = new Windows.UI.Popups.MessageDialog("You have to protect your king");
    //            checkmessege.ShowAsync();
    //            return;
    //        }
    //        // checking if there is an enemy on the chosen cell
    //        Chess enemy = PlayGround.figures.Find(x => x.position == newLocation);
    //        // if there is an enemy , it will be removed from the desk and figures collection
    //        if (enemy != null)
    //        {
    //            figures.Remove(enemy);
    //            enemy.RemoveFromPlayGround();
    //        }
    //        //setting figures new position
    //        figure.position = newLocation;
    //        figure.Locate();
    //        //if the figure is pawn, it can make tocells step but only if it`s her first move,otherwise only onecell step
    //        if (figure is Pawn)
    //        {
    //            var pawn = (Pawn)(figure);
    //            if (pawn.isItTheFirstMove)
    //            {
    //                pawn.isItTheFirstMove = false;
    //            }
    //        }
    //        //after the move MovingTeam and Label`s values should  be changed to  oposite team
    //        PlayGround.MovingTeam = PlayGround.MovingTeam == Chess.Team.white ? Chess.Team.black : Chess.Team.white;
    //        // if team has check game will show a messege to the player
    //        if (IsATeamChecked(MovingTeam, PlayGround.figures))
    //        {
    //            if(IsItAMate(MovingTeam))
    //            {
    //                Windows.UI.Popups.MessageDialog lose = new Windows.UI.Popups.MessageDialog("You lost,{0}", MovingTeam.ToString());
    //                lose.ShowAsync();
    //            }
    //            else
    //            {
    //                Windows.UI.Popups.MessageDialog teamChecked = new Windows.UI.Popups.MessageDialog("Ops,you`re checked :(");
    //                teamChecked.ShowAsync();
    //            }
    //        }
    //        TeamMoving.Text = PlayGround.MovingTeam.ToString();
    //    }
    //    // checkes is a team checked or not
    //    private static bool IsATeamChecked(Chess.Team team, List<Chess> figures)
    //    {
    //        // finds team`s king
    //        Chess king = figures.Find(x => x.team == team && x is King);
    //        foreach (Chess figure in figures)
    //        {
    //            // if enemy can get to team`s king it means team has check
    //            if (figure.team != team && figure.IsTheMovePossible(king.position, figures))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //    // checkes will current move produse cheack for team or not
    //    private static bool WillResultWithCheck(Chess movingFigure, Location destination)
    //    {
    //        // simulating a clone list of figures collection with changing cordinates for moving figure
    //        List<Chess> simulated = new List<Chess>();
    //        foreach (Chess figure in PlayGround.figures)
    //        {
    //            if (figure.position == destination)
    //            {
    //                continue;
    //            }
    //            var clonedFigure = figure.clone();
    //            if (figure == movingFigure)
    //            {
    //                clonedFigure.position = destination;
    //            }
    //            simulated.Add(clonedFigure);
    //        }
    //        // checking if team with new location has check
    //        return IsATeamChecked(movingFigure.team, simulated);
    //    }
    //    public static void Castling(King king, Location location)
    //    {
    //        if(king.isItTheFirstMove)
    //        {
    //            if(location.column > king.position.column)
    //            {
    //                location.column--; 
    //                var rook = PlayGround.figures.Find(x => x is Rook && x.position.column == 7 && x.team == king.team && ((Rook)(x)).isItTheFirstMove == true);
    //                if(rook!=null && rook.IsTheMovePossible(location,PlayGround.figures))
    //                {
    //                    rook.position.column -= 2;
    //                    king.position.column += 2;
    //                    king.isItTheFirstMove = false;
    //                    (rook as Rook).isItTheFirstMove = false;
    //                    rook.Locate();
    //                    king.Locate();
    //                    PlayGround.MovingTeam = PlayGround.MovingTeam == Chess.Team.white ? Chess.Team.black : Chess.Team.white;
    //                    TeamMoving.Text = PlayGround.MovingTeam.ToString();
    //                }
    //            }
    //            else
    //            {
    //                location.column++;
    //                var rook = PlayGround.figures.Find(x => x is Rook && x.position.column == 0 && x.team == king.team && ((Rook)(x)).isItTheFirstMove == true);
    //                if (rook != null && rook.IsTheMovePossible(location, PlayGround.figures))
    //                {
    //                    rook.position.column += 3;
    //                    king.position.column -= 2;
    //                    king.isItTheFirstMove = false;
    //                    (rook as Rook).isItTheFirstMove = false;
    //                    rook.Locate();
    //                    king.Locate();
    //                    PlayGround.MovingTeam = PlayGround.MovingTeam == Chess.Team.white ? Chess.Team.black : Chess.Team.white;
    //                    TeamMoving.Text = PlayGround.MovingTeam.ToString();
    //                }
    //            }                
                
    //        }
    //        // if team has check game will show a messege to the player
    //        if (IsATeamChecked(MovingTeam, PlayGround.figures))
    //        {
    //            if (IsItAMate(MovingTeam))
    //            {
    //                Windows.UI.Popups.MessageDialog lose = new Windows.UI.Popups.MessageDialog("You lost,{0}", MovingTeam.ToString());
    //                lose.ShowAsync();
    //            }
    //            else
    //            {
    //                Windows.UI.Popups.MessageDialog teamChecked = new Windows.UI.Popups.MessageDialog("Ops,you`re checked :(");
    //                teamChecked.ShowAsync();
    //            }
    //        }

    //        return;
    //    }

    //    private static bool IsItAMate(Chess.Team team)
    //    {
    //        foreach (Chess figure in PlayGround.figures.FindAll(x => x.team == team))
    //        {

    //            for (int i = 0; i < 8; i++)
    //            {
    //                for (int j = 0; j < 8; j++)
    //                {
    //                    Location candidate = new Location { row = i, column = j };
    //                    if (figure.IsTheMovePossible(candidate, PlayGround.figures) && !WillResultWithCheck(figure, candidate))
    //                    {
    //                        return false;
    //                    }
    //                }
    //            }
    //        }
    //        return true;
    //    }
    //}
}

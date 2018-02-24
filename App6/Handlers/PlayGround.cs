using App6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Handlers
{
    public class PlayGroung
    {
        //    public static void Move(object sendingFigure, RoutedEventArgs e, Models.Location location, Models.Chess currentMovingFigure,List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        //    {
        //        // checking is there any movin figure on the desk
        //        if (currentMovingFigure != null)
        //        {
        //            if (currentMovingFigure is Models.King && Math.Abs(location.column - (currentMovingFigure as King).position.column) == 2)
        //            {
        //                Castling(sendingFigure,e,currentMovingFigure as King, location,figures,ref MovingTeam,TeamMovingIndicator);
        //            }
        //            // checking can the figure stand on current cell
        //            else if (currentMovingFigure.IsTheMovePossible(location, figures))
        //            {
        //                // unreleasing figure`s cell and moving her to the new place
        //                currentMovingFigure.highlightHandler(sendingFigure, e, currentMovingFigure.position, false);
        //                MoveFigure(currentMovingFigure, location,figures,ref MovingTeam,TeamMovingIndicator);
        //            }
        //            // if move is not possible player will see a messege
        //            else
        //            {
        //                Viewes.PlayGround.MoveNotPossibleMessege();
        //            }
        //            // changing current moving figure`s value to null
        //            currentMovingFigure.highlightHandler(sendingFigure, e, currentMovingFigure.position, false);
        //            currentMovingFigure = null;
        //        }
        //    }
        //    public static void Castling(object sendingFigure, RoutedEventArgs e,King king, Location location,List<Models.Chess> figures,ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        //    {
        //        if (king.isItTheFirstMove)
        //        {
        //            int rookOriginalColumn;
        //            int rookFinalColumn;
        //            int kingFinalColumn;
        //            if(location.column > king.position.column)
        //            {
        //                rookOriginalColumn = 7;
        //                rookFinalColumn = 5;
        //                kingFinalColumn = 6;
        //                location.column--;
        //            }
        //            else
        //            {
        //                rookOriginalColumn = 0;
        //                rookFinalColumn = 3;
        //                kingFinalColumn = 2;
        //                location.column++;
        //            }
        //            var rook = figures.Find(x => x is Rook && x.position.column == rookOriginalColumn && x.team == king.team && ((Rook)(x)).isItTheFirstMove == true);
        //            if (rook != null && rook.IsTheMovePossible(location, figures))
        //            {
        //                king.highlightHandler(sendingFigure, e, king.position, false);
        //                rook.position = new Location { column = rookFinalColumn, row = rook.position.row };
        //                king.position = new Location { column = kingFinalColumn, row = king.position.row };
        //                Viewes.PlayGround.Locate(rook);
        //                Viewes.PlayGround.Locate(king);
        //                MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
        //                Viewes.PlayGround.MovingTeamSwitcher(TeamMovingIndicator, MovingTeam.ToString());
        //            }
        //        }
        //    }

        //    public static void Click(object sender, RoutedEventArgs e, Models.Location location, List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock MovingTeamIndicator)
        //    {
        //        // checking is there any movin figure on the desk
        //        if (PlayGround.currentMovingFigure != null)
        //        {
        //            if (PlayGround.currentMovingFigure is Models.King && Math.Abs(location.column - ((Models.King)(PlayGround.currentMovingFigure)).position.column) == 2)
        //            {
        //                PlayGroung.Castling(sender, e, (Models.King)(PlayGround.currentMovingFigure), location, figures,ref MovingTeam, MovingTeamIndicator);
        //            }
        //            // checking can the figure stand on current cell
        //            else if (PlayGround.currentMovingFigure.IsTheMovePossible(location, figures))
        //            {
        //                // unreleasing figure`s cell and moving her to the new place
        //                PlayGround.currentMovingFigure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
        //                PlayGroung.Move(sender, e, location, Models.PlayGround.currentMovingFigure, figures, ref Models.PlayGround.MovingTeam, Models.PlayGround.TeamMoving);
        //            }
        //            // if move is not possible player will see a messege
        //            else
        //            {
        //                Viewes.PlayGround.MoveNotPossibleMessege();
        //            }
        //            // changing current moving figure`s value to null
        //            PlayGround.currentMovingFigure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
        //            PlayGround.currentMovingFigure = null;
        //        }
        //    }
        //    public static void MoveHandler(object sender, RoutedEventArgs e, Models.Chess figure,List<Models.Chess> figures)
        //    {
        //        if (PlayGround.currentMovingFigure == null)
        //        {
        //            if (figure.team == PlayGround.MovingTeam)
        //            {
        //                PlayGround.currentMovingFigure = figure;
        //                figure.highlightHandler(sender, e, figure.position);
        //            }
        //        }
        //        else
        //        {
        //            int y = Grid.GetColumn((FrameworkElement)sender);
        //            int x = Grid.GetRow((FrameworkElement)sender);
        //            Models.Location position1 = new Models.Location() { row = x, column = y };
        //            if (PlayGround.currentMovingFigure.IsTheMovePossible(figure.position, figures))
        //            {
        //                PlayGround.currentMovingFigure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
        //                PlayGroung.Move(sender, e, position1, Models.PlayGround.currentMovingFigure, figures, ref Models.PlayGround.MovingTeam, Models.PlayGround.TeamMoving);
        //            }
        //            else
        //            {
        //                Viewes.PlayGround.MoveNotPossibleMessege();
        //            }
        //            figure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
        //            PlayGround.currentMovingFigure = null;
        //        }
        //    }
        //public static void MoveFigure(Models.Chess figure, Location newLocation, List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        //{
        //    //if the move will produce a check for figures team move will be canceled
        //    if (WillResultWithCheck(figure, newLocation, figures))
        //    {
        //        Viewes.PlayGround.PotentialCheckMessege();
        //        return;
        //    }
        //    // checking if there is an enemy on the chosen cell
        //    Models.Chess enemy = figures.Find(x => x.position == newLocation);
        //    // if there is an enemy , it will be removed from the desk and figures collection
        //    if (enemy != null)
        //    {
        //        figures.Remove(enemy);
        //        Viewes.PlayGround.Remove(Models.PlayGround.playGround, enemy);
        //    }
        //    //setting figures new position
        //    figure.position = newLocation;
        //    Viewes.PlayGround.Locate(figure);

        //    //after the move MovingTeam and Label`s values should  be changed to  oposite team
        //    MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
        //    // if team has check game will show a messege to the player
        //    if (IsATeamChecked(MovingTeam, figures))
        //    {
        //        if (IsItAMate(MovingTeam, figures))
        //        {
        //            Windows.UI.Popups.MessageDialog lose = new Windows.UI.Popups.MessageDialog("You lost,{0}", MovingTeam.ToString());
        //            lose.ShowAsync();
        //        }
        //        else
        //        {
        //            Windows.UI.Popups.MessageDialog teamChecked = new Windows.UI.Popups.MessageDialog("Ops,you`re checked :(");
        //            teamChecked.ShowAsync();
        //        }
        //    }
        //    Viewes.PlayGround.MovingTeamSwitcher(TeamMovingIndicator, MovingTeam.ToString());
        //}
        //    // checkes is a team checked or not
        //private static bool IsATeamChecked(Models.Chess.Team team, List<Models.Chess> figures)
        //{
        //    // finds team`s king
        //    Models.Chess king = figures.Find(x => x.team == team && x is King);
        //    foreach (Models.Chess figure in figures)
        //    {
        //        // if enemy can get to team`s king it means team has check
        //        if (figure.team != team && figure.IsTheMovePossible(king.position, figures))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //// checkes will current move produse cheack for team or not
        //private static bool WillResultWithCheck(Models.Chess movingFigure, Location destination, List<Models.Chess> figures)
        //{
        //    // simulating a clone list of figures collection with changing cordinates for moving figure
        //    List<Models.Chess> simulated = new List<Models.Chess>();
        //    foreach (Models.Chess figure in figures)
        //    {
        //        if (figure.position == destination)
        //        {
        //            continue;
        //        }
        //        var clonedFigure = figure.clone();
        //        if (figure == movingFigure)
        //        {
        //            clonedFigure.position = destination;
        //        }
        //        simulated.Add(clonedFigure);
        //    }
        //    // checking if team with new location has check
        //    return IsATeamChecked(movingFigure.team, simulated);
        //}
        //private static bool IsItAMate(Models.Chess.Team team, List<Models.Chess> figures)
        //{
        //    foreach (Models.Chess figure in figures.FindAll(x => x.team == team))
        //    {
        //        for (int i = 0; i < 8; i++)
        //        {
        //            for (int j = 0; j < 8; j++)
        //            {
        //                Location candidate = new Location { row = i, column = j };
        //                if (figure.IsTheMovePossible(candidate, figures) && !WillResultWithCheck(figure, candidate, figures))
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}

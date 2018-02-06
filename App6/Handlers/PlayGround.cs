﻿using App6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Handlers
{
    class _PlayGround
    {
        public static void Move(object sendingFigure, RoutedEventArgs e, Models.Location location, Models.Chess currentMovingFigure,List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        {
            // checking is there any movin figure on the desk
            if (currentMovingFigure != null)
            {
                if (currentMovingFigure is Models.King && Math.Abs(location.column - (currentMovingFigure as King).position.column) == 2)
                {
                    Castling(sendingFigure,e,currentMovingFigure as King, location,figures,MovingTeam,TeamMovingIndicator);
                }
                // checking can the figure stand on current cell
                else if (currentMovingFigure.IsTheMovePossible(location, figures))
                {
                    // unreleasing figure`s cell and moving her to the new place
                    currentMovingFigure.highlightHandler(sendingFigure, e, currentMovingFigure.position, false);
                    MoveFigure(currentMovingFigure, location,figures,ref MovingTeam,TeamMovingIndicator);
                }
                // if move is not possible player will see a messege
                else
                {
                    Viewes.PlayGround.MoveNotPossibleMessege();
                }
                // changing current moving figure`s value to null
                currentMovingFigure.highlightHandler(sendingFigure, e, currentMovingFigure.position, false);
                currentMovingFigure = null;
            }
        }
        public static void Castling(object sendingFigure, RoutedEventArgs e,King king, Location location,List<Models.Chess> figures,Models.Chess.Team MovingTeam, TextBlock TeamMovingIndicator)
        {
            if (king.isItTheFirstMove)
            {
                if (location.column > king.position.column)
                {
                    location.column--;
                    var rook = figures.Find(x => x is Rook && x.position.column == 7 && x.team == king.team && ((Rook)(x)).isItTheFirstMove == true);
                    if (rook != null && rook.IsTheMovePossible(location, figures))
                    {
                        king.highlightHandler(sendingFigure, e, king.position, false);
                        rook.position = new Location { column = rook.position.column - 2, row = rook.position.row };
                        king.position = new Location { column = king.position.column + 2, row = king.position.row };
                        rook.Locate();
                        king.Locate();
                        MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
                        Viewes.PlayGround.MovingTeamSwitcher(TeamMovingIndicator,MovingTeam.ToString());
                    }
                }
                else
                {
                    location.column++;
                    var rook = PlayGround.figures.Find(x => x is Rook && x.position.column == 0 && x.team == king.team && ((Rook)(x)).isItTheFirstMove == true);
                    if (rook != null && rook.IsTheMovePossible(location, figures))
                    {
                        rook.position = new Location { column = rook.position.column + 3, row = rook.position.row };
                        king.position = new Location { column = king.position.column - 2, row = king.position.row };
                        rook.Locate();
                        king.Locate();
                        MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
                        Viewes.PlayGround.MovingTeamSwitcher(TeamMovingIndicator,MovingTeam.ToString());
                    }
                }

            }
        }
        public static void MoveFigure(Models.Chess figure, Location newLocation,List<Models.Chess> figures, ref Models.Chess.Team MovingTeam, TextBlock  TeamMovingIndicator)
        {
            //if the move will produce a check for figures team move will be canceled
            if (WillResultWithCheck(figure, newLocation,figures))
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
                enemy.RemoveFromPlayGround();
            }
            //setting figures new position
            figure.position = newLocation;
            figure.Locate();

            //after the move MovingTeam and Label`s values should  be changed to  oposite team
            MovingTeam = MovingTeam == Models.Chess.Team.white ? Models.Chess.Team.black : Models.Chess.Team.white;
            // if team has check game will show a messege to the player
            if (IsATeamChecked(MovingTeam,figures))
            {
                if (IsItAMate(MovingTeam,figures))
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
        // checkes is a team checked or not
        private static bool IsATeamChecked(Models.Chess.Team team, List<Models.Chess> figures)
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
        private static bool WillResultWithCheck(Models.Chess movingFigure, Location destination, List<Models.Chess> figures)
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
        private static bool IsItAMate(Models.Chess.Team team, List<Models.Chess> figures)
        {
            foreach (Models.Chess figure in figures.FindAll(x => x.team == team))
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Location candidate = new Location { row = i, column = j };
                        if (figure.IsTheMovePossible(candidate, figures) && !WillResultWithCheck(figure, candidate,figures))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
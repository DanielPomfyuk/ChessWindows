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
    class Chess
    {
        public static object Team { get; internal set; }

        public static void MoveHandler(object sender, RoutedEventArgs e,Models.Chess figure)
        {
            if (PlayGround.currentMovingFigure == null)
            {
                if (figure.team == PlayGround.MovingTeam)
                {
                    PlayGround.currentMovingFigure = figure;
                    figure.highlightHandler(sender, e, figure.position);
                }
            }
            else
            {
                int y = Grid.GetColumn((FrameworkElement)sender);
                int x = Grid.GetRow((FrameworkElement)sender);
                Models.Location position1 = new Models.Location() { row = x, column = y };
                if (PlayGround.currentMovingFigure.IsTheMovePossible(figure.position, PlayGround.figures))
                {
                    PlayGround.currentMovingFigure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
                    _PlayGround.Move(sender,e,position1,Models.PlayGround.currentMovingFigure,Models.PlayGround.figures,ref Models.PlayGround.MovingTeam,Models.PlayGround.TeamMoving);
                }
                else
                {
                    Viewes.PlayGround.MoveNotPossibleMessege();
                }
                figure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
                PlayGround.currentMovingFigure = null;
            }
        }
    }
}

using App6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace App6.Handlers
{
    class Cell
    {
        public static void CellMove(object sender, RoutedEventArgs e, Models.Location location,List<Models.Chess> figures,ref Models.Chess.Team MovingTeam,TextBlock MovingTeamIndicator )
        {
            // checking is there any movin figure on the desk
            if (PlayGround.currentMovingFigure != null)
            {
                if (PlayGround.currentMovingFigure is Models.King && Math.Abs(location.column - ((Models.King)(PlayGround.currentMovingFigure)).position.column) == 2)
                {
                    PlayGroung.Castling(sender,e,(Models.King)(PlayGround.currentMovingFigure), location,figures,MovingTeam,MovingTeamIndicator);
                }
                // checking can the figure stand on current cell
                else if (PlayGround.currentMovingFigure.IsTheMovePossible(location, PlayGround.figures))
                {
                    // unreleasing figure`s cell and moving her to the new place
                    PlayGround.currentMovingFigure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
                    PlayGroung.Move(sender, e, location, Models.PlayGround.currentMovingFigure, Models.PlayGround.figures, ref Models.PlayGround.MovingTeam, Models.PlayGround.TeamMoving);
                }
                // if move is not possible player will see a messege
                else
                {
                    Viewes.PlayGround.MoveNotPossibleMessege();
                }
                // changing current moving figure`s value to null
                PlayGround.currentMovingFigure.highlightHandler(sender, e, PlayGround.currentMovingFigure.position, false);
                PlayGround.currentMovingFigure = null;
            }
        }        
        public static void ChangeFocus(Models.Cell cell, bool focused = true)
        {
            //moving figure stands on current cell nothing will happen
            if (PlayGround.currentMovingFigure != null && PlayGround.currentMovingFigure.position == cell.location)
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
        public static void Pressed(Models.Cell cell)
        {   //if there is moving figure on the desk her cell`s fill will turn red()pressed mode    
            if (PlayGround.currentMovingFigure != null)
            {
                Viewes.Cell.ChangeColor(cell, Models.Cell.Types.pressed);
            }
        }
    }
}

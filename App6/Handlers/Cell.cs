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
    public class Cell
    {
       
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

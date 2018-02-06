using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Models
{
    class Bishop : Chess
    {
        public Bishop(FrameworkElement gridControlElement, Location position, Team colour, Grid playGround, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, playGround, highLightHandler)
        {
        }
        public override bool IsTheMovePossible(Location locationOfThePotentialCell, List<Chess> figures)
        {
            if (!base.IsTheMovePossible(locationOfThePotentialCell, figures))
            {
                return false;
            }
            int difference = Math.Abs(this.position.row - locationOfThePotentialCell.row);
            return Math.Abs(this.position.column - locationOfThePotentialCell.column) == difference;
        }
    }
}

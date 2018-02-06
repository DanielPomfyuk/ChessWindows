using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Models
{
    class Queen : Chess
    {
        public Queen(FrameworkElement gridControlElement, Location position, Team colour, Grid playGround, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, playGround, highLightHandler)
        {
        }
        public override bool IsTheMovePossible(Location locationOfThePotentialCell, List<Chess> figures)
        {
            if (!base.IsTheMovePossible(locationOfThePotentialCell, figures))
            {
                return false;
            }
            bool rookThing = locationOfThePotentialCell.row == this.position.row || locationOfThePotentialCell.column == this.position.column;
            int difference = Math.Abs(this.position.row - locationOfThePotentialCell.row);
            bool bishop = Math.Abs(this.position.column - locationOfThePotentialCell.column) == difference;
            return rookThing || bishop;
        }
    }
}

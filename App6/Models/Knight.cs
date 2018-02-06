using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Models
{
    class Knight : Chess
    {
        public Knight(FrameworkElement gridControlElement, Location position, Team colour, Grid playGround, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, playGround, highLightHandler)
        {
        }
        public override bool IsTheMovePossible(Location locationOfThePotentialCell, List<Chess> figures)
        {
            int differenceOfColums = Math.Abs(this.position.column - locationOfThePotentialCell.column);
            int differenceOfRows = Math.Abs(this.position.row - locationOfThePotentialCell.row);
            return differenceOfColums != 0 && differenceOfRows != 0 && differenceOfRows + differenceOfColums == 3;
        }
    }
}

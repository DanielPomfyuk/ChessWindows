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
    class Queen : Chess
    {
        public Queen(Team color, PlayGround.HighLightHandler highLightHandler) :base(color,highLightHandler)
        {
            Image queen = new Image();
            BitmapImage bmw;
            if (color == Team.white)
            {
                this.position = new Location() { row = 0, column = 3 };
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteQueenNew.png"));
            }
            else
            {
                this.position = new Location() { row = 7, column = 3 };
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackQueenNew.png"));
            }
            queen.Source = bmw;
            queen.HorizontalAlignment = HorizontalAlignment.Center;
            queen.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = queen;
            this.gridControlElement.PointerPressed += this.MoveHandler;
        }
        public Queen(FrameworkElement gridControlElement, Location position, Team colour, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, highLightHandler)
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

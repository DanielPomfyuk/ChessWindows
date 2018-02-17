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
    public class Queen : Chess
    {
        public Queen(Team color, PlayGround.HighLightHandler highLightHandler) :base(color,highLightHandler)
        {
            Image queen = new Image();
            this._position = new Location() { row = color == Team.white ? 0 : 7, column = 3 };
            queen.Source = new BitmapImage(new Uri(color == Team.white ? "ms-appx:///Assets/whiteQueenNew.png" : "ms-appx:///Assets/blackQueenNew.png"));
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

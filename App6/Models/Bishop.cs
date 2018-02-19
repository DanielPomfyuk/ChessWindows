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
    public class Bishop : Chess
    {
        // This is bishop,not bi shop)
        public Bishop(Team color, PlayGround.HighLightHandler highLightHandler,bool isLeft = false) :base(color,highLightHandler)
        {
            Image bishop = new Image();
            this.position = new Location() { column = isLeft ? 2 : 5, row = color == Team.white ? 0 : 7 };
            bishop.Source = new BitmapImage(new Uri(color == Team.white ? "ms-appx:///Assets/whiteBishop.png" : "ms-appx:///Assets/blackBishop.png"));
            bishop.HorizontalAlignment = HorizontalAlignment.Center;
            bishop.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = bishop;
            this.gridControlElement.PointerPressed += this.MoveHandler;
        }
        public Bishop(FrameworkElement gridControlElement, Location position, Team colour, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, highLightHandler)
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

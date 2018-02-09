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
    class Bishop : Chess
    {
        // This is bishop,not bi shop)
        public Bishop(Team color, PlayGround.HighLightHandler highLightHandler) :base(color,highLightHandler)
        {
            Image bishop = new Image();
            BitmapImage bmw;
            if (color == Team.white)
            {
                var twin = Models.PlayGround.figures.Find(x => x.position == new Location() { row = 0, column = 2 });
                if (twin == null)
                {
                    this.position = new Location() { row = 0, column = 2 };
                }
                else
                {
                    this.position = new Location() { row = 0, column = 5 };
                }
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteBishop.png"));
            }
            else
            {
                var twin = Models.PlayGround.figures.Find(x => x.position == new Location() { row = 7, column = 2 });
                if (twin == null)
                {
                    this.position = new Location() { row = 7, column = 2 };
                }
                else
                {
                    this.position = new Location() { row = 7, column = 5 };
                }
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackBishop.png"));
            }
            bishop.Source = bmw;
            bishop.HorizontalAlignment = HorizontalAlignment.Center;
            bishop.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = bishop;
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

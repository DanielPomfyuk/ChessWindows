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
    class Knight : Chess
    {
        public Knight(Team color, PlayGround.HighLightHandler highLightHandler) :base(color,highLightHandler)
        {
            Image knight = new Image();
            BitmapImage bmw;
            if (color == Team.white)
            {
                var twin = Models.PlayGround.figures.Find(x => x.position == new Location() { row = 0, column = 1 });
                if(twin == null)
                {
                    this.position = new Location() { row = 0, column = 1 };
                }
                else
                {
                    this.position = new Location() { row = 0, column = 6 };
                }
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteKnight.png"));
            }
            else
            {
                var twin = Models.PlayGround.figures.Find(x => x.position == new Location() { row = 7, column = 1 });
                if (twin == null)
                {
                    this.position = new Location() { row = 7, column = 1 };
                }
                else
                {
                    this.position = new Location() { row = 7, column = 6 };
                }
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackKnight.png"));
            }
            knight.Source = bmw;
            knight.HorizontalAlignment = HorizontalAlignment.Center;
            knight.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = knight;
        }
        public Knight(FrameworkElement gridControlElement, Location position, Team colour, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, highLightHandler)
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

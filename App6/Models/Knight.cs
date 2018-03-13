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
    public class Knight : Chess
    {
        public Knight(Team color,bool isLeft = false) : base(color)
        {
            Image knight = new Image();
            this.position = new Location() { column = isLeft ? 1 : 6, row = color == Team.white ? 0 : 7 };
            knight.Source = new BitmapImage(new Uri(color == Team.white ? "ms-appx:///Assets/whiteKnight.png" : "ms-appx:///Assets/blackKnight.png"));
            knight.HorizontalAlignment = HorizontalAlignment.Center;
            knight.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = knight;
        }
        public Knight(FrameworkElement gridControlElement, Location position, Team colour) : base(gridControlElement, position, colour)
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

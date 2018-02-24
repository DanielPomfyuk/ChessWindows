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
    public class King : Chess
    {
        private bool _isItTheFirstMove = true;
        public King(Team color, PlayGround.HighLightHandler highLightHandler) : base(color, highLightHandler)
        {
            Image king = new Image();
            this._position = new Location() { row = color == Team.white ? 0 : 7, column = 4 };
            king.Source = new BitmapImage(new Uri(color == Team.white ? "ms-appx:///Assets/whiteKing.png" : "ms-appx:///Assets/blackKing.png"));
            king.HorizontalAlignment = HorizontalAlignment.Center;
            king.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = king;
        }
        public King(FrameworkElement gridControlElement, Location position, Team colour, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, highLightHandler)
        {
        }
        public bool isItTheFirstMove
        {
            get
            {
                return this._isItTheFirstMove;
            }
        }
        public override Location position
        {
            get
            {
                return base.position;
            }
            set
            {
                this._isItTheFirstMove = false;
                base.position = value;
            }
        }
        public override bool IsTheMovePossible(Location locationOfThePotentialCell, List<Chess> figures)
        {
            if (!base.IsTheMovePossible(locationOfThePotentialCell, figures))
            {
                return false;
            }
            bool rowDifference = Math.Abs(this.position.row - locationOfThePotentialCell.row) <= 1;
            bool columnDifference = Math.Abs(this.position.column - locationOfThePotentialCell.column) <= 1;
            return columnDifference && rowDifference;
        }
    }
}

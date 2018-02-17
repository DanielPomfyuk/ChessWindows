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
    public class Rook : Chess
    {
        private bool _isItTheFirstMove = true;
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
        public Rook(Team color, PlayGround.HighLightHandler highLightHandler, bool isLeft = false) :base(color,highLightHandler)
        {
            Image rook = new Image();          
            this._position = new Location() { column = isLeft ? 0 : 7, row = color == Team.white ? 0 : 7 };
            rook.Source = new BitmapImage(new Uri(color == Team.white ? "ms-appx:///Assets/whiteRook.png" : "ms-appx:///Assets/blackRook.png"));
            rook.HorizontalAlignment = HorizontalAlignment.Center;
            rook.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = rook;
            this.gridControlElement.PointerPressed += this.MoveHandler;
        }
        public Rook(FrameworkElement gridControlElement, Team colour, PlayGround.HighLightHandler highLightHandler, Location position) : base(gridControlElement, position, colour, highLightHandler)
        {
        }

        public override bool IsTheMovePossible(Location locationOfThePotentialCell, List<Chess> figures)
        {
            if (!base.IsTheMovePossible(locationOfThePotentialCell, figures))
            {
                return false;
            }
            return locationOfThePotentialCell.row == this.position.row || locationOfThePotentialCell.column == this.position.column;
        }
    }
}

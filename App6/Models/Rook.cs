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
    class Rook : Chess
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
        public Rook(Team color, PlayGround.HighLightHandler highLightHandler) :base(color,highLightHandler)
        {
            Image rook = new Image();
            BitmapImage bmw;
            if (color == Team.white)
            {
                var twin = Models.PlayGround.figures.Find(x => x.position == new Location() { row = 0, column = 0 });
                if (twin == null)
                {
                    this.position = new Location() { row = 0, column = 0 };
                }
                else
                {
                    this.position = new Location() { row = 0, column = 7 };
                }
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/whiteRook.png"));
            }
            else
            {
                var twin = Models.PlayGround.figures.Find(x => x.position == new Location() { row = 7, column = 0 });
                if (twin == null)
                {
                    this.position = new Location() { row = 7, column = 0 };
                }
                else
                {
                    this.position = new Location() { row = 7, column = 7 };
                }
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackRook.png"));
            }
            rook.Source = bmw;
            rook.HorizontalAlignment = HorizontalAlignment.Center;
            rook.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = rook;
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

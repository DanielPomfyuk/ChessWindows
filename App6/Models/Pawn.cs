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

    class Pawn : Chess
    {
        private bool _isItTheFirstMove = true;
        public Pawn(Team color, PlayGround.HighLightHandler highLightHandler,Location location) :base(color,highLightHandler)
        {
            Image pawn = new Image();
            BitmapImage bmw;
            if (color == Team.white)
            {
                this.position = location;
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/whitePawn.png"));
            }
            else
            {
                this.position = location;
                bmw = new BitmapImage(new Uri("ms-appx:///Assets/blackPawn.png"));
            }
            pawn.Source = bmw;
            pawn.HorizontalAlignment = HorizontalAlignment.Center;
            pawn.VerticalAlignment = VerticalAlignment.Center;
            this.gridControlElement = pawn;
        }
        public Pawn(FrameworkElement gridControlElement, Location position, Team colour, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, highLightHandler)
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
            Chess enemy = figures.Find(x => x.position == locationOfThePotentialCell);
            int possibleSteps = isItTheFirstMove ? 2 : 1;
            if (enemy != null)
            {
                if (this.team == Team.white)
                {
                    return (Math.Abs(this.position.column - enemy.position.column) == 1 && enemy.position.row == this.position.row + 1);
                }
                else
                {
                    return (Math.Abs(this.position.column - enemy.position.column) == 1 && enemy.position.row == this.position.row - 1);

                }
            }
            if (locationOfThePotentialCell.column == this.position.column)
            {
                if (this.team == Team.white)
                {
                    return locationOfThePotentialCell.row <= this.position.row + possibleSteps && locationOfThePotentialCell.row > this.position.row;
                }
                else
                {
                    return locationOfThePotentialCell.row >= this.position.row - possibleSteps && locationOfThePotentialCell.row < this.position.row;
                }
            }
            return false;
        }
    }
}

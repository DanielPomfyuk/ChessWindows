using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        public Rook(FrameworkElement gridControlElement, Location position, Team colour, Grid playGround, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, playGround, highLightHandler)
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

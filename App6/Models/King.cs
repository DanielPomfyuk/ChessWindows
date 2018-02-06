using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Models
{
    class King : Chess
    {
        private bool _isItTheFirstMove = true;
        public King(FrameworkElement gridControlElement, Location position, Team colour, Grid playGround, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, playGround, highLightHandler)
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

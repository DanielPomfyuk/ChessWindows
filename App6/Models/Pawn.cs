using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Models
{

    class Pawn : Chess
    {
        private bool _isItTheFirstMove = true;
        public Pawn(FrameworkElement gridControlElement, Location position, Team colour, Grid playGround, PlayGround.HighLightHandler highLightHandler) : base(gridControlElement, position, colour, playGround, highLightHandler)
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

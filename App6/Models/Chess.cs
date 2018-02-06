using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Models
{
    //data type which represends figures location on the desk
    public struct Location
    {
        public int row;
        public int column;
        public static bool operator ==(Location locationOne, Location locationTwo)
        {
            return locationOne.Equals(locationTwo);

        }
        public static bool operator !=(Location locationOne, Location locationTwo)
        {
            return !locationOne.Equals(locationTwo);

        }

        public override string ToString()
        {
            return String.Format("The row is {0}, the column is {1}", this.row, this.column);
        }
    }
    abstract class Chess
    {
        //constructor
        public Chess(FrameworkElement gridControlElement, Location position, Team team, Grid playGround, PlayGround.HighLightHandler highLightHandler)
        {
            this.gridControlElement = gridControlElement;
            this._position = position;
            this._team = team;
            this.playGround = playGround;
            this.highlightHandler = highLightHandler;
            this.playGround.Children.Add(this.gridControlElement);
            this.gridControlElement.PointerPressed += this.MoveHandler;
        }
        protected Grid playGround;
        private Location _position;
        protected FrameworkElement gridControlElement;
        public PlayGround.HighLightHandler highlightHandler;
        public enum Team { white, black };
        private Team _team;
        public virtual Team team
        {
            get
            {
                return this._team;
            }
        }
        public Chess clone()
        {
            return (Chess)this.MemberwiseClone();
        }
        //handler for moving operations
        private void MoveHandler(object sender, RoutedEventArgs e)
        {
            Handlers.Chess.MoveHandler(sender, e, this);
        }
        //adds fidurs to the board
        public void Locate()
        {
            Grid.SetColumn(this.gridControlElement, this.position.column);
            Grid.SetRow(this.gridControlElement, this.position.row);
        }
        public virtual Location position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }
        public void RemoveFromPlayGround()
        {
            playGround.Children.Remove(this.gridControlElement);
        }
        private bool IsVerticallyMidle(Location destination, Location middleCandidate)
        {
            int max = destination.row > this.position.row ? destination.row : this.position.row;
            int min = destination.row < this.position.row ? destination.row : this.position.row;
            return middleCandidate.row < max && middleCandidate.row > min;
        }
        private bool isHorizontalyMidle(Location destination, Location middleCandidate)
        {
            int max = destination.column > this.position.column ? destination.column : this.position.column;
            int min = destination.column < this.position.column ? destination.column : this.position.column;
            return middleCandidate.column < max && middleCandidate.column > min;
        }
        private bool isOnline(Location destination, Location middleCandidate)
        {
            double x = ((Double)(middleCandidate.column) - this.position.column) / (destination.column - this.position.column);
            double y = ((Double)(middleCandidate.row) - this.position.row) / (destination.row - this.position.row);
            return x == y;
        }
        public bool IsInTheMiddle(Location destination, Location middleCandidate)
        {
            if (this.position.column == destination.column)
            {
                return this.IsVerticallyMidle(destination, middleCandidate) && destination.column == middleCandidate.column;
            }
            else if (this.position.row == destination.row)
            {
                return this.isHorizontalyMidle(destination, middleCandidate) && destination.row == middleCandidate.row;
            }
            else
            {
                return this.IsVerticallyMidle(destination, middleCandidate) && this.isOnline(destination, middleCandidate);
            }
        }
        virtual public bool IsTheMovePossible(Location locationOfThePotentialCell, List<Chess> figures)
        {
            foreach (Chess figure in figures)
            {
                if (figure.position == locationOfThePotentialCell && figure.team == this.team)
                {
                    return false;
                }
                if (this.IsInTheMiddle(locationOfThePotentialCell, figure.position))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

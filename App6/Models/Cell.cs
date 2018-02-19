using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace App6.Models
{
    public class Cell
    {
        //constructor
        public Cell(Types types, Location location, Grid playGround)
        {
            this.type = types;
            this.location = location;
            this.playGround = playGround;
        }
        private Grid playGround;
        public Rectangle rectangle;
        public Types type;
        //an enum of all types of cell`s possible in the game
        public enum Types { white, black, focused, pressed };
        //a collection of types of cells and colours which suppose to represend those types
        public static Dictionary<Types, Color> cellColors = new Dictionary<Types, Color>()
        {
            {Types.white, Colors.BurlyWood },
            {Types.black, Colors.SaddleBrown},
            {Types.focused, Colors.Yellow },
            {Types.pressed, Colors.Red }
        };
        public Location location;
        //handler for cell`s pressed event
        private void CellMove(object sender, RoutedEventArgs e)
        {
            Handlers.PlayGroung.Click(sender, e, this.location,Models.PlayGround.figures,ref Models.PlayGround.MovingTeam,Models.PlayGround.TeamMoving);
        }
        //handler for cell`s focused event
        private void CellFocused(object sender, RoutedEventArgs e)
        {
            Handlers.Cell.ChangeFocus(this);

        }
        //handler for cell`s disfocud event
        private void CellDisFocused(object sender, RoutedEventArgs e)
        {
            Handlers.Cell.ChangeFocus(this, false);
        }
        //handler for cell`s pressed event
        public void Pressed(object sender, RoutedEventArgs e)
        {
            Handlers.Cell.Pressed(this);
        }


        //creates a rectangle which will represend a cell on the desk
        public void Locate()
        {
            this.rectangle = new Rectangle();
            this.rectangle.Height = 570 / 8;
            this.rectangle.Width = rectangle.Height;
            this.rectangle.Fill = new SolidColorBrush(Cell.cellColors[this.type]);
            Grid.SetRow(rectangle, this.location.row);
            Grid.SetColumn(rectangle, this.location.column);
            playGround.Children.Add(this.rectangle);
            this.rectangle.PointerPressed += this.CellMove;
            this.rectangle.PointerEntered += this.CellFocused;
            this.rectangle.PointerExited += this.CellDisFocused;
            this.rectangle.PointerPressed += this.Pressed;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App6.Viewes
{
    class PlayGround
    {
        public static void MoveNotPossibleMessege()
        {
            Windows.UI.Popups.MessageDialog message = new Windows.UI.Popups.MessageDialog("Move is not possible");
            message.ShowAsync();
        }
        public static void PotentialCheckMessege()
        {
            Windows.UI.Popups.MessageDialog checkmessege = new Windows.UI.Popups.MessageDialog("You have to protect your king");
            checkmessege.ShowAsync();
        }
        public static void MovingTeamSwitcher(TextBlock label, string newText)
        {
            label.Text = newText;
        }
        public static void Locate(Models.Chess figure)
        {
            Grid.SetColumn(figure.gridControlElement, figure.position.column);
            Grid.SetRow(figure.gridControlElement, figure.position.row);
        }
        public static void Add(Grid playGround , Models.Chess figure)
        {
            playGround.Children.Add(figure.gridControlElement);
        }
        public static void Remove(Grid playGround, Models.Chess figure)
        {
            playGround.Children.Remove(figure.gridControlElement);
        }
    }
}

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
    }
}

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
        public static void LoseMessage(Models.Chess.Team MovingTeam)
        {
            Windows.UI.Popups.MessageDialog lose = new Windows.UI.Popups.MessageDialog("You lost,{0}", MovingTeam.ToString());
            lose.ShowAsync();
        }
        public static void CheckMessage()
        {
            Windows.UI.Popups.MessageDialog teamChecked = new Windows.UI.Popups.MessageDialog("Ops,you`re checked :(");
            teamChecked.ShowAsync();
        }
        public static void MovingTeamSwitcher(App6.Models.Chess.Team team)
        {
            Models.PlayGround.WhiteTeamIndicator.Stroke = team == Models.Chess.Team.white ? new SolidColorBrush(Colors.Black) : null;
            Models.PlayGround.blackTeamIndicator.Stroke = team == Models.Chess.Team.black ? new SolidColorBrush(Colors.Black) : null;
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

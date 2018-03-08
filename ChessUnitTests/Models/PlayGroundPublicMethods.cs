using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App6;
using App6.Models;

namespace ChessUnitTests.Models
{
    [TestClass]
    public class PlayGroundPublicMethods
    {
        private static Grid mainWindow = new Grid();
        private object Moсk_sender;
        private RoutedEventArgs Moсk_e;
        private App6.Models.Chess.Team Moсk_MovingTeam = App6.Models.Chess.Team.white;
        private TextBlock Moсk_TeamMoving = new TextBlock();
        [UITestMethod]
        public void Casling()
        {
            List<App6.Models.Chess> figures = new List<Chess>();
            List<App6.Models.Cell> cells = new List<Cell>();
            App6.Models.King king = new App6.Models.King(Chess.Team.white);
            App6.Models.Rook rook = new App6.Models.Rook(Chess.Team.white);
            figures.Add(king);
            figures.Add(rook);
            for (int i = 0; i < 8; i++)
            {
                //cell`s colour depends on it`s possition
                for (int j = 0; j < 8; j++)
                {
                    App6.Models.Cell.Types type;
                    if ((i + j) % 2 == 1)
                    {
                        type = App6.Models.Cell.Types.black;
                    }
                    else
                    {
                        type = App6.Models.Cell.Types.white;
                    }
                    App6.Models.Cell rectangle = new App6.Models.Cell(type, new Location { row = i, column = j });
                    cells.Add(rectangle);
                }
            }
            Moсk_TeamMoving.Text = "white";
            PlayGround playGround = new PlayGround(mainWindow, figures, cells);
            Grid newPlayGRound = new Grid();
            foreach(Cell cell in cells)
            {
                cell.Locate(newPlayGRound);
            }
            // if it is figures` first moves and there`s nothing on their way casling should be allowed
            playGround.Castling(Moсk_sender, Moсk_e, king, new Location() { row = 0, column = 6 }, figures, ref Moсk_MovingTeam, Moсk_TeamMoving);
            Assert.IsTrue(king.position == new Location() { row = 0, column = 6 } && rook.position == new Location() { row = 0, column = 5 });
            Assert.IsTrue(Moсk_TeamMoving.Text == Moсk_MovingTeam.ToString());

        }

    }
}

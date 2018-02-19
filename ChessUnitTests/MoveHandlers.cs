using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using App6.Models;
using Windows.UI.Xaml.Controls;

namespace ChessUnitTests
{
    [TestClass]
    public class MoveHandlers
    {
        object MockSender = new object();
        RoutedEventArgs MockE = new RoutedEventArgs();
        App6.Models.Location MockDestination = new App6.Models.Location() { row = 5, column = 3 };
        Chess.Team MockMovingTeam = Chess.Team.white;
        TextBlock MockIndicator = new TextBlock();
        bool wasMethodCalled = false;
        private void MockHighlightHandler(object sender, RoutedEventArgs e, App6.Models.Location location, bool press = true)
        {
            wasMethodCalled = true;
        }

        [UITestMethod]
        public void CellClickMove()
        {
            List<Chess> MockFigures = new List<Chess>();
            MockFigures.Add(new App6.Models.Queen(Chess.Team.white, MockHighlightHandler));
            Assert.IsNull(App6.Models.PlayGround.currentMovingFigure);
            PlayGround.currentMovingFigure = MockFigures[0];
            App6.Handlers.PlayGroung.Click(MockSender, MockE, MockDestination, MockFigures, ref MockMovingTeam, MockIndicator);
            Assert.IsNull(PlayGround.currentMovingFigure);
            Assert.IsTrue(wasMethodCalled);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ChessUnitTests
{
    [TestClass]
    public class King
    {
        List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
        App6.Models.King king = new App6.Models.King(App6.Models.Chess.Team.white, HighlightHandler);
        private static void HighlightHandler(object sender, RoutedEventArgs e, App6.Models.Location location, bool press = true)
        {

        }
        [UITestMethod]
        public void IsTheMovePossibleKing()
        {
            figures.Add(king);
            //if the move is not further than 1 cell any way than move should be allowed
            Assert.IsTrue(king.IsTheMovePossible(new App6.Models.Location() { row = 1, column = 4 },figures));
            Assert.IsTrue(king.IsTheMovePossible(new App6.Models.Location() { row = 1, column = 5 }, figures));
            Assert.IsTrue(king.IsTheMovePossible(new App6.Models.Location() { row = 0, column = 5 }, figures));
            Assert.IsTrue(king.IsTheMovePossible(new App6.Models.Location() { row = 0, column = 3 }, figures));
            Assert.IsTrue(king.IsTheMovePossible(new App6.Models.Location() { row = 1, column = 3 }, figures));
        }
        [UITestMethod]
        public void IsItTheFirstMoveKing()
        {
            //before king makes a step his "IsItTheFirstMove" field should be true
            Assert.IsTrue(king.isItTheFirstMove);
            //after king`s first move the value should change to false
            king.position = new App6.Models.Location() { row = 1, column = 4 };
            Assert.IsFalse(king.isItTheFirstMove);
        }
    }
}

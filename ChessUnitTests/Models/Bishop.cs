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
    public class Bishop
    {
        private static void HighlightHandler(object sender, RoutedEventArgs e, App6.Models.Location location, bool press = true)
        {

        }
        [UITestMethod]
        public void IsTheMovePossibleBishop()
        {
            List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
            App6.Models.Bishop bishop = new App6.Models.Bishop(App6.Models.Chess.Team.white, HighlightHandler, true);
            figures.Add(bishop);
            //bishop can go anywhere diagonally
            bishop.position = new App6.Models.Location() { row = 4, column = 4 };
            Assert.IsTrue(bishop.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 3 }, figures));
            Assert.IsTrue(bishop.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 5 }, figures));
            Assert.IsTrue(bishop.IsTheMovePossible(new App6.Models.Location() { row = 6, column = 2 }, figures));
            Assert.IsTrue(bishop.IsTheMovePossible(new App6.Models.Location() { row = 7, column = 7 }, figures));
        }
        [UITestMethod]
        public void MoveIsImpossibleBishop()
        {
            List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
            App6.Models.Bishop bishop = new App6.Models.Bishop(App6.Models.Chess.Team.white, HighlightHandler, true);
            figures.Add(bishop);
            //bishop can`t make a move if destination is not on diagonal line with him 
            bishop.position = new App6.Models.Location() { row = 4, column = 4 };
            Assert.IsFalse(bishop.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 0 }, figures));
        }
    }
}

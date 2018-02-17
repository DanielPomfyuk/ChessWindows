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
    public class Knight
    {
        private static void HighlightHandler(object sender, RoutedEventArgs e, App6.Models.Location location, bool press = true)
        {

        }
        [UITestMethod]
        public void IsTheMovePossibleKnight()
        {
            List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
            App6.Models.Knight knight = new App6.Models.Knight(App6.Models.Chess.Team.white, HighlightHandler, true);
            knight.position = new App6.Models.Location() { row = 4, column = 4 };
            figures.Add(knight);
            //if move is two cells front/back and one right/left move should be allowed
            //moves to front:
            //move to right
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 2,column = 5}, figures));
            //move to left
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 3 }, figures));
            //moves to back:
            //move to right
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 6, column = 5 }, figures));
            //move to left
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 6, column = 3 }, figures));
            //if move is two cells right/left and one front/back move should be allowed
            //moves right:
            //move front
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 6 }, figures));
            //move back
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 5, column = 6 }, figures));
            //moves left:
            //move front
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 2 }, figures));
            Assert.IsTrue(knight.IsTheMovePossible(new App6.Models.Location() { row = 5, column = 2 }, figures));
        }
    }
}

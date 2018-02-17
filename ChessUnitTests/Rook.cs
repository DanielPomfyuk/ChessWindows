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
    public class Rook
    {
      
        private static void HighlightHandler(object sender, RoutedEventArgs e, App6.Models.Location location, bool press = true)
        {

        }
        [UITestMethod]
        public void IsTheMovePossibleRook()
        {
            List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
            App6.Models.Rook rook = new App6.Models.Rook(App6.Models.Chess.Team.white, HighlightHandler,true);
            figures.Add(rook);
            //Rook can go anywhere while destination is horizontaly or verticaly online with it
            Assert.IsTrue(rook.IsTheMovePossible(new App6.Models.Location() { row = 0, column = 3 }, figures));
            Assert.IsTrue(rook.IsTheMovePossible(new App6.Models.Location() { row = 4, column = 0 }, figures));
        }
        [UITestMethod]
        public void IsItTheFirstMoveRook()
        {
            App6.Models.Rook rook = new App6.Models.Rook(App6.Models.Chess.Team.white, HighlightHandler,true);
            //before rook makes a step his "IsItTheFirstMove" field should be true
            Assert.IsTrue(rook.isItTheFirstMove);
            //after rook`s first move the value should change to false
            rook.position = new App6.Models.Location() { row = 1, column = 4 };
            Assert.IsFalse(rook.isItTheFirstMove);
        }
    }
}

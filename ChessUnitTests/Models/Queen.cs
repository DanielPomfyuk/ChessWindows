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
    public class Queen
    {
        List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
        App6.Models.Queen queen = new App6.Models.Queen(App6.Models.Chess.Team.white);
        [UITestMethod]
        public void IsTheMovePossibleQueen()
        {
            figures.Add(queen);
            //Queen can go anywhere while destination is horizontaly , verticaly or diagonally online with her
            Assert.IsTrue(queen.IsTheMovePossible(new App6.Models.Location() { row = 5, column = 3 }, figures));
            Assert.IsTrue(queen.IsTheMovePossible(new App6.Models.Location() { row = 0, column = 7 }, figures));
            Assert.IsTrue(queen.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 0 }, figures));
            //Queen can`t reach the destination if if it is not on atleast one line
            Assert.IsFalse(queen.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 7 }, figures));
        }
    }
}

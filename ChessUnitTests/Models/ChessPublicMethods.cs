using App6.Models;
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
    public class ChessPublicMethods
    {
        App6.Models.Queen queen = new App6.Models.Queen(Chess.Team.black);
        [UITestMethod]
        public void Clone()
        {
            var newQueen = queen.clone();
            Assert.AreNotEqual(newQueen, queen);
            Assert.AreEqual(newQueen.gridControlElement,queen.gridControlElement);
            Assert.AreEqual(newQueen.position, queen.position);
        }
        [UITestMethod]
        public void IsInTheMiddle()
        {
            //if candidate is between figure and destination and all of them are on the same row result should be true
            Assert.IsTrue(queen.IsInTheMiddle(new Location() { row = 7, column = 6 }, new Location() { row = 7, column = 5 }));
            //if candidate , figure and destination qre all  on the same row but candidate is not between figure and destination result should be false
            Assert.IsFalse(queen.IsInTheMiddle(new Location() { row = 7, column = 5 }, new Location() { row = 7, column = 6 }));

            //if candidate is between figure and destination and all of them are on the same column result should be true
            Assert.IsTrue(queen.IsInTheMiddle(new Location() { row = 5, column = 3 }, new Location() { row = 6, column = 3 }));
            //if candidate figure and destination are on the same column but candidate is not between figure and destination result should be false
            Assert.IsFalse(queen.IsInTheMiddle(new Location() { row = 6, column = 3 }, new Location() { row = 5, column = 3 }));

            //if candidate is between figure and destination and all of them are on the same diagonal result should be true
            Assert.IsTrue(queen.IsInTheMiddle(new Location() { row = 5, column = 5 }, new Location() { row = 6, column = 4 }));
            //if candidate  figure and destination  are on the same diagonal but candidate is not between figure and destination result should be false 
            Assert.IsFalse(queen.IsInTheMiddle(new Location() { row = 6, column = 4 }, new Location() { row = 5, column = 5 }));

            //if candidate is not horizontaly,verticaly or diagonally between figure and destination result should be false
            Assert.IsFalse(queen.IsInTheMiddle(new Location() { row = 7, column = 4 }, new Location() { row = 0, column = 0 }));
        }
        [UITestMethod]
        public void LocationOperators()
        {
            //Locations with simmilar rows and columns should be equal
            Assert.IsTrue(new Location() { row = 0, column = 0 } == new Location() { row = 0, column = 0 });
            Assert.IsFalse(new Location() { row = 0, column = 0 } != new Location() { row = 0, column = 0 });
            //Locations with different rows and columns should not be equal
            Assert.IsTrue(new Location() { row = 0, column = 2 } != new Location() { row = 0, column = 0 });
            Assert.IsFalse(new Location() { row = 0, column = 2 } == new Location() { row = 0, column = 0 });
        }

    }
}

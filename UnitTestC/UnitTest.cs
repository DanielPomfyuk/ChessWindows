
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App6.Models;
using Windows.UI.Xaml;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace UnitTestC
{
    [TestClass]
    public class MovingLogicTest
    {
        [UITestMethod]
        public void TestMethod1()
        {
            List<App6.Models.Chess> figures = new List<Chess>();
            App6.Models.Location location = new Location() { row = 1, column = 3 };
            Pawn pawn = new App6.Models.Pawn(App6.Models.Chess.Team.white, DummyHighlightCell, location);
            figures.Add(pawn);
            Assert.IsTrue(pawn.IsTheMovePossible(new Location() { row =4, column = 3 }, figures));
        }
        public void DummyHighlightCell(object sender, RoutedEventArgs e, Location location, bool press = true)
        {
        }
    }
}

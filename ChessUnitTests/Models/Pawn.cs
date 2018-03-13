
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using Windows.UI.Xaml;
using System.Collections.Generic;
using App6.Models;

namespace ChessUnitTests
{
    
    [TestClass]
    public class Pawn
    {

        [UITestMethod]
        public void ISTheMovePossiblePawn()
        {
            List<App6.Models.Chess> figures = new List<App6.Models.Chess>();
            App6.Models.Pawn pawn = new App6.Models.Pawn(App6.Models.Chess.Team.white, new App6.Models.Location() { row = 1, column = 3 });
            figures.Add(pawn);
            //First move to 1 row forward should be possible
            Assert.IsTrue(pawn.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 3 }, figures));
            //First move to 2 rows forward should be possible
            Assert.IsTrue(pawn.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 3 }, figures));
            //First move to 3 or more rows forward should not be possible
            Assert.IsFalse(pawn.IsTheMovePossible(new App6.Models.Location() { row = 4, column = 3 }, figures));
            //Move back should not be allowed
            Assert.IsFalse(pawn.IsTheMovePossible(new App6.Models.Location() { row = 0, column = 3 }, figures));
            pawn.position = new Location() { row = 1, column = 4 };
            //If it is not pawn`s first move a two rows forward step should not be allowed
            Assert.IsFalse(pawn.IsTheMovePossible(new App6.Models.Location() { row = 3, column = 4 }, figures));
            //One step forward should be allowd even if it is not pawn`s first move
            Assert.IsTrue(pawn.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 4 }, figures));
            //Move diagonally without killing the enemy should not be allowed
            Assert.IsFalse(pawn.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 5 }, figures));
            //Move diagonally with enemy on that cell should be allowed
            figures.Add(new App6.Models.Pawn(App6.Models.Chess.Team.black, new App6.Models.Location() { row = 2, column = 5 }));
            Assert.IsTrue(pawn.IsTheMovePossible(new App6.Models.Location() { row = 2, column = 5 }, figures));
        }
    }
    
}

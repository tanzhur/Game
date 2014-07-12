using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace UnitTestsKingSurvival
{
    [TestClass]
    public class PieceKingTests
    {
        private readonly PieceKing piece = new PieceKing();
        private readonly Coordinates coords = new Coordinates(4, 4);

        [TestMethod]
        public void TestPieceKingInitializationAndIDSetWithRealChar()
        {
            piece.ID = 'a';
            Assert.AreEqual('a', piece.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPieceKingInitializationAndIDSetWithIncorrectValueNumber()
        {
            piece.ID = '4';
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPieceKingInitializationAndIDSetWithIncorrectSpecialSymbol()
        {
            piece.ID = '#';
        }

        [TestMethod]
        public void TestPieceKingSetCoordinatesToACorrectValue()
        {
            piece.Coordinates = coords;
            Assert.AreEqual(coords, piece.Coordinates);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPieceKingSetCoordinatesToANullValueForCoordinates()
        {
            piece.Coordinates = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPieceKingSubscribeToGamePieceObserver()
        {
            piece.Coordinates = null;
        }
    }
}

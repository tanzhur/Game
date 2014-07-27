namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class PieceTests
    {
        private readonly Piece piece = new PieceKing();
        private readonly Coordinate coords = new Coordinate(4, 4);
        private readonly bool currentTestRan = true;
        private readonly GameBoard gameBoard = new GameBoard();

        // Methods for tests that will be equal to those for other pieces PiecePawn for example testing parent class methods
        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPieceInitializationAndIDSetWithRealChar()
        {
            piece.ID = 'K';
            Assert.AreEqual('K', piece.ID);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceSetCoordinatesToACorrectValue()
        {
            piece.Coordinates = coords;
            Assert.AreEqual(coords, piece.Coordinates);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPieceInitializationAndIDSetWithIncorrectValueNumber()
        {
            piece.ID = '4';
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPieceInitializationAndIDSetWithIncorrectSpecialSymbol()
        {
            piece.ID = '#';
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPieceSetCoordinatesToANullValueForCoordinates()
        {
            piece.Coordinates = null;
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceMoveToACorrectValue(){
            Coordinate newCoords = new Coordinate(5, 5);
            piece.Move(newCoords);
            Assert.AreEqual(newCoords, piece.Coordinates);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestPieceMoveToACorrectValueWithDelegateSet()
        {   
            Coordinate newCoords = new Coordinate(5, 5);
            piece.Moved += gameBoard.Notify;
            piece.Move(newCoords);
            Assert.AreEqual(newCoords, piece.Coordinates);
        }
    }
}

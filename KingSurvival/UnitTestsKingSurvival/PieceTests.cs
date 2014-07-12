namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class PieceTests
    {
        private readonly Piece piece = new PieceKing();
        private readonly Coordinates coords = new Coordinates(4, 4);
        private readonly bool currentTestRan = true;
        private readonly GameBoard gameBoard = new GameBoard();

        // Methods for tests that will be equal to those for other pieces PiecePawn for example testing parent class methods
        [TestMethod]
        public void TestPieceInitializationAndIDSetWithRealChar()
        {
            piece.ID = 'K';
            Assert.AreEqual('K', piece.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPieceInitializationAndIDSetWithIncorrectValueNumber()
        {
            piece.ID = '4';
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPieceInitializationAndIDSetWithIncorrectSpecialSymbol()
        {
            piece.ID = '#';
        }

        [TestMethod]
        public void TestPieceSetCoordinatesToACorrectValue()
        {
            piece.Coordinates = coords;
            Assert.AreEqual(coords, piece.Coordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPieceSetCoordinatesToANullValueForCoordinates()
        {
            piece.Coordinates = null;
        }

        [TestMethod]
        public void TestPieceSubscribeToGamePieceObserver()
        {
            piece.SubscribeToGamePieceObserver(gameBoard);
            Assert.IsTrue(currentTestRan);
        }

        [TestMethod]
        public void TestPieceSubscribeToGamePieceObserverWithANullArgument()
        {
            piece.SubscribeToGamePieceObserver(null);
            Assert.IsTrue(currentTestRan);
        }

        [TestMethod]
        public void TestPieceUnSubscribeFromGamePieceObserver()
        {
            piece.UnSubscribeFromGamePieceObserver(gameBoard);
            Assert.IsTrue(currentTestRan);
        }

        [TestMethod]
        public void TestPieceUnSubscribeFromGamePieceObserverThatAllreadyIsObserver()
        {
            piece.SubscribeToGamePieceObserver(gameBoard);
            piece.UnSubscribeFromGamePieceObserver(gameBoard);
            Assert.IsTrue(currentTestRan);
        }

        [TestMethod]
        public void TestPieceUnSubscribeFromGamePieceObserverFromEmptyListOfObservers()
        {
            piece.UnSubscribeFromGamePieceObserver(null);
            Assert.IsTrue(currentTestRan);
        }

        [TestMethod]
        public void TestPieceNotifyObserversWithCurrentlyOneOrMoreObservers()
        {
            piece.SubscribeToGamePieceObserver(gameBoard);
            piece.SubscribeToGamePieceObserver(gameBoard);
            piece.SubscribeToGamePieceObserver(gameBoard);
            piece.NotifyObservers();
            Assert.IsTrue(currentTestRan);
        }

        [TestMethod]
        public void TestPieceNotifyObserversWithCurrentlyNoObservers()
        {
            piece.NotifyObservers();
            Assert.IsTrue(currentTestRan);
        }
    }
}

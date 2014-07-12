namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class GameBoardTests
    {
        private readonly Piece pieceKing = new PieceKing();
        private readonly Coordinates coords = new Coordinates(4, 4);
        private readonly GameBoard board = new GameBoard();
        private const bool TestRanThrough = true;
        private const int DefaultWidth = 21;
        private const int DefaultHeight = 11;
        private const int DefaultTotalFieldSize = 8;

        [TestMethod]
        public void TestGameBoardInitialization()
        {
            GameBoard boardTest = new GameBoard();
            Assert.IsTrue(TestRanThrough);
        }

        [TestMethod]
        public void TestGameBoardWidthIfItIsTheCorrectDefaultValue()
        {
            bool testResult = board.Width == DefaultWidth;
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TestGameBoardHeightIfItIsTheCorrectDefaultValue()
        {
            bool testResult = board.Height == DefaultHeight;
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TestGameBoardTotalFieldSizeCorrect()
        {
            bool testResult = board.PlayfieldSize == DefaultTotalFieldSize;
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TestGameBoardImageCorrectness()
        {
            var matrix = board.Image;

            bool testResult = ((matrix.GetLength(1) == DefaultWidth) && (matrix.GetLength(0) == DefaultHeight));
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TestGameBoard()
        {
            var matrix = board.Image;

            bool testResult = ((matrix.GetLength(1) == DefaultWidth) && (matrix.GetLength(0) == DefaultHeight));
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TestGameBoardTryFindIDOnBoard()
        {
            pieceKing.ID = 'K';
            pieceKing.Coordinates = coords;
            pieceKing.SubscribeToGamePieceObserver(board);
            board.Notify('K', new Coordinates(5,5));

            Assert.IsTrue(TestRanThrough);
        }
    }
}

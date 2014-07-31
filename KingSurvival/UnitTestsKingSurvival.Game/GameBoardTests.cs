namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.GameObjects.Board;
    using KingSurvival.Game.Common;

    [TestClass]
    public class GameBoardTests
    {
        private readonly Piece pieceKing = new PieceKing();
        private readonly Coordinate coords = new Coordinate(4, 4);
        private readonly GameBoard board = new GameBoard();
        private const bool TestRanThrough = true;
        private const int DefaultWidth = 21;
        private const int DefaultHeight = 11;
        private const int DefaultTotalFieldSize = 8;

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestGameBoardInitialization()
        {
            new GameBoard();
            Assert.IsTrue(TestRanThrough);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestGameBoardWidthIfItIsTheCorrectDefaultValue()
        {
            bool testResult = board.Width == DefaultWidth;
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestGameBoardHeightIfItIsTheCorrectDefaultValue()
        {
            bool testResult = board.Height == DefaultHeight;
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestGameBoardTotalFieldSizeCorrect()
        {
            bool testResult = board.PlayfieldSize == DefaultTotalFieldSize;
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestGameBoardImageCorrectness()
        {
            var matrix = board.Image;

            bool testResult = ((matrix.GetLength(1) == DefaultWidth) && (matrix.GetLength(0) == DefaultHeight));
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestGameBoard()
        {
            var matrix = board.Image;

            bool testResult = ((matrix.GetLength(1) == DefaultWidth) && (matrix.GetLength(0) == DefaultHeight));
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestGameBoardInstance()
        {
            var matrix = GameBoard.Instance;

            bool result = true;

            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    if (matrix.Image[i,j] != board.Image[i,j])
                    {
                        result = false;
                    }
                }
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void AssertNoExceptionIsThrownInNotifyMethod()
        {
            pieceKing.Coordinates = coords;
            board.Notify(pieceKing, new Coordinate(5, 5));
        }
    }
}

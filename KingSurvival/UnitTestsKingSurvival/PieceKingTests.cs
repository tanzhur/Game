namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using KingSurvival.Enums;

    [TestClass]
    public class PieceKingTests
    {
        private readonly Piece pieceKing = new PieceKing();
        private readonly Coordinate coords = new Coordinate(4, 4);

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPieceKingGetNewCoordinatesWithUpLeftMove()
        {
            Moves move = Moves.UpLeft;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X - 1) == pieceKing.Coordinates.X) && ((coords.Y - 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPieceKingGetNewCoordinatesWithUpRightMove()
        {
            Moves move = Moves.UpRight;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X + 1) == pieceKing.Coordinates.X) && ((coords.Y - 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPieceKingGetNewCoordinatesWithDownLeftMove()
        {
            Moves move = Moves.DownLeft;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X - 1) == pieceKing.Coordinates.X) && ((coords.Y + 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPieceKingGetNewCoordinatesWithDownRightMove()
        {
            Moves move = Moves.DownRight;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X + 1) == pieceKing.Coordinates.X) && ((coords.Y + 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPieceKingGetNewCoordinatesWithInValidMove()
        {
            Moves move = (Moves)5;
            pieceKing.Coordinates = coords;
            var result = pieceKing.GetNewCoordinates(move);

            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceKingIsValidMoveWithValidMoveDownRight()
        {
            bool result = pieceKing.IsValidMove(Moves.DownRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceKingIsValidMoveWithValidMoveDownLeft()
        {
            bool result = pieceKing.IsValidMove(Moves.DownLeft);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceKingIsValidMoveWithValidMoveUpRight()
        {
            bool result = pieceKing.IsValidMove(Moves.UpRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceKingIsValidMoveWithValidMoveUpLeft()
        {
            bool result = pieceKing.IsValidMove(Moves.UpLeft);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPieceKingMoveWithValidNewCoordinates()
        {
            Coordinate newCoords = new Coordinate(3, 3);
            pieceKing.Coordinates = coords;
            pieceKing.Move(newCoords);

            bool result = ((pieceKing.Coordinates.X == newCoords.X) && (pieceKing.Coordinates.Y == newCoords.Y));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPieceKingMoveWithInValidNewCoordinates()
        {
            pieceKing.Coordinates = coords;
            pieceKing.Move(null);
        }
    }
}

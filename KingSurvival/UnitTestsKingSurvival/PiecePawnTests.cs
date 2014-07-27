
namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using KingSurvival.Enums;

    [TestClass]
    public class PiecePawnTests
    {
        private readonly Piece piecePawn = new PiecePawn();
        private readonly Coordinate coords = new Coordinate(4, 4);

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPiecePawnGetNewCoordinatesWithDownLeftMove()
        {
            Moves move = Moves.DownLeft;
            piecePawn.Coordinates = coords;
            piecePawn.Coordinates = piecePawn.GetNewCoordinates(move);

            bool result = ((coords.X - 1) == piecePawn.Coordinates.X) && ((coords.Y + 1) == piecePawn.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPiecePawnGetNewCoordinatesWithDownRightMove()
        {
            Moves move = Moves.DownRight;
            piecePawn.Coordinates = coords;
            piecePawn.Coordinates = piecePawn.GetNewCoordinates(move);

            bool result = ((coords.X + 1) == piecePawn.Coordinates.X) && ((coords.Y + 1) == piecePawn.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPiecePawnGetNewCoordinatesWithInValidMove()
        {
            Moves move = (Moves)5;
            piecePawn.Coordinates = coords;
            var result = piecePawn.GetNewCoordinates(move);

            Assert.IsNull(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsValidMoveWithValidMoveDownRight()
        {
            bool result = piecePawn.IsValidMove(Moves.DownRight);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsValidMoveWithValidMoveDownLeft()
        {
            bool result = piecePawn.IsValidMove(Moves.DownLeft);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsInvalidMoveWithValidMoveUpLeft()
        {
            bool result = piecePawn.IsValidMove(Moves.UpLeft);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsInvalidMoveWithValidMoveUpRight()
        {
            bool result = piecePawn.IsValidMove(Moves.UpRight);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnMoveWithValidNewCoordinates()
        {
            Coordinate newCoords = new Coordinate(3, 3);
            piecePawn.Coordinates = coords;
            piecePawn.Move(newCoords);

            bool result = ((piecePawn.Coordinates.X == newCoords.X) && (piecePawn.Coordinates.Y == newCoords.Y));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPiecePawnMoveWithInValidNewCoordinates()
        {
            piecePawn.Coordinates = coords;
            piecePawn.Move(null);
        }
    }
}

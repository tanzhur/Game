
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
        private readonly Coordinates coords = new Coordinates(4, 4);
        private char pieceID = 'A';

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
        public void TestPiecePawnIsValidCommandWithValidCommandID()
        {
            piecePawn.ID = pieceID;
            Moves move = Moves.DownRight;
            Command command = new Command(pieceID, move);

            bool result = piecePawn.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsValidCommandWithInValidCommandID()
        {
            piecePawn.ID = pieceID;
            Moves move = Moves.DownRight;
            Command command = new Command('K', move);

            bool result = piecePawn.IsValidCommand(command);

            Assert.IsTrue(!result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsValidCommandWithValidCommandMoveDownLeft()
        {
            piecePawn.ID = pieceID;
            Moves move = Moves.DownLeft;
            Command command = new Command(pieceID, move);

            bool result = piecePawn.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsValidCommandWithValidCommandMoveDownRight()
        {
            piecePawn.ID = pieceID;
            Moves move = Moves.DownRight;
            Command command = new Command(pieceID, move);

            bool result = piecePawn.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnIsValidCommandWithInValidCommand()
        {
            piecePawn.ID = pieceID;
            Moves move = (Moves)5;
            Command command = new Command(pieceID, move);

            bool result = piecePawn.IsValidCommand(command);

            Assert.IsTrue(!result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestPiecePawnMoveWithValidNewCoordinates()
        {
            Coordinates newCoords = new Coordinates(3, 3);
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

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
        private readonly Coordinates coords = new Coordinates(4, 4);

        [TestMethod]
        public void TestPieceKingGetNewCoordinatesWithUpLeftMove()
        {
            Moves move = Moves.UpLeft;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X - 1) == pieceKing.Coordinates.X) && ((coords.Y - 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingGetNewCoordinatesWithUpRightMove()
        {
            Moves move = Moves.UpRight;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X + 1) == pieceKing.Coordinates.X) && ((coords.Y - 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingGetNewCoordinatesWithDownLeftMove()
        {
            Moves move = Moves.DownLeft;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X - 1) == pieceKing.Coordinates.X) && ((coords.Y + 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingGetNewCoordinatesWithDownRightMove()
        {
            Moves move = Moves.DownRight;
            pieceKing.Coordinates = coords;
            pieceKing.Coordinates = pieceKing.GetNewCoordinates(move);

            bool result = ((coords.X + 1) == pieceKing.Coordinates.X) && ((coords.Y + 1) == pieceKing.Coordinates.Y);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingGetNewCoordinatesWithInValidMove()
        {
            Moves move = (Moves)5;
            pieceKing.Coordinates = coords;
            var result = pieceKing.GetNewCoordinates(move);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithValidCommandID()
        {
            pieceKing.ID = 'K';
            Moves move = Moves.DownRight;
            Command command = new Command('K', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithInValidCommandID()
        {
            pieceKing.ID = 'K';
            Moves move = Moves.DownRight;
            Command command = new Command('A', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(!result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithValidCommandMoveDownLeft()
        {
            pieceKing.ID = 'K';
            Moves move = Moves.DownLeft;
            Command command = new Command('K', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithValidCommandMoveDownRight()
        {
            pieceKing.ID = 'K';
            Moves move = Moves.DownRight;
            Command command = new Command('K', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithValidCommandMoveUpLeft()
        {
            pieceKing.ID = 'K';
            Moves move = Moves.UpLeft;
            Command command = new Command('K', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithValidCommandMoveUpRight()
        {
            pieceKing.ID = 'K';
            Moves move = Moves.UpRight;
            Command command = new Command('K', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestPieceKingIsValidCommandWithInValidCommand()
        {
            pieceKing.ID = 'K';
            Moves move = (Moves)5;
            Command command = new Command('K', move);

            bool result = pieceKing.IsValidCommand(command);

            Assert.IsTrue(!result);
        }

        [TestMethod]
        public void TestPieceKingMoveWithValidNewCoordinates()
        {
            Coordinates newCoords = new Coordinates(3, 3);
            pieceKing.Coordinates = coords;
            pieceKing.Move(newCoords);

            bool result = ((pieceKing.Coordinates.X == newCoords.X) && (pieceKing.Coordinates.Y == newCoords.Y));

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestPieceKingMoveWithInValidNewCoordinates()
        {
            pieceKing.Coordinates = coords;
            pieceKing.Move(null);
        }
    }
}

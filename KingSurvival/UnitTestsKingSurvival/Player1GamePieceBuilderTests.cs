namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class Player1GamePieceBuilderTests
    {

        [TestMethod]
        public void Player1GamePieceBuilderTestCreatePieceMethod()
        {
            var builder = CreateBuilder();
            builder.CreatePiece();

            bool result = builder.GetType() == typeof(Player1GamePieceBuilder);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Player1GamePieceBuilderTestSetPieceCoordinatesMethod()
        {
            var builder = CreateBuilder();
            builder.CreatePiece();
            builder.SetPieceID();
            builder.SetPieceCoordinates();
            var piece = builder.GetPiece();

            bool result = ((piece.Coordinates.X == 3) && (piece.Coordinates.Y == 7));

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Player1GamePieceBuilderTestCreatePieceAndGetPieceMethod()
        {
            var builder = CreateBuilder();
            builder.CreatePiece();
            builder.SetPieceID();
            var piece = builder.GetPiece();

            bool result = piece.ID == 'K';

            Assert.IsTrue(result);
        }

        private PlayersGamePieceBuilder CreateBuilder()
        {
            var factory = new PawnsAndKingsFactory();
            PlayersGamePieceBuilder builder = new Player1GamePieceBuilder(factory);

            return builder;
        }
    }
}

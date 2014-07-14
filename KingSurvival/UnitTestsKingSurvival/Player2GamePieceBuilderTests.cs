
namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    
    [TestClass]
    public class Player2GamePieceBuilderTests
    {
        [TestMethod]
        public void Player2GamePieceBuilderTestCreatePieceMethod()
        {
            var builder = CreateBuilder();
            builder.CreatePiece();

            bool result = builder.GetType() == typeof(Player2GamePieceBuilder);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Player2GamePieceBuilderTestSetPieceCoordinatesMethod()
        {
            var builder = CreateBuilder();
            builder.CreatePiece();
            builder.SetPieceID();
            builder.SetPieceCoordinates();
            var piece = builder.GetPiece();

            bool result = ((piece.Coordinates.X == 0) && (piece.Coordinates.Y == 0));

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Player2GamePieceBuilderTestCreatePieceAndGetPieceMethod()
        {
            var builder = CreateBuilder();
            builder.CreatePiece();
            builder.SetPieceID();
            var piece = builder.GetPiece();

            bool result = piece.ID == 'A';

            Assert.IsTrue(result);
        }

        private PlayersGamePieceBuilder CreateBuilder()
        {
            var factory = new PawnsAndKingsFactory();
            PlayersGamePieceBuilder builder = new Player2GamePieceBuilder(factory);

            return builder;
        }
    }
}

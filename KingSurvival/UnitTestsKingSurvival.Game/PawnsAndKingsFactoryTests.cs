namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.GameInitializer;
    using KingSurvival.Game.Interfaces;

    [TestClass]
    public class PawnsAndKingsFactoryTests
    {
        private readonly PawnsAndKingsFactory factory = new PawnsAndKingsFactory();

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void FactoryMakingPieceKingWithCreatePlayer1Piece()
        {
            IPiece piecePawn = factory.CreatePlayer1Piece();

            bool result = piecePawn.GetType() == typeof(PieceKing);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void FactoryMakingPiecePawnWithCreatePlayer2Piece()
        {
            IPiece piecePawn = factory.CreatePlayer2Piece();

            bool result = piecePawn.GetType() == typeof(PiecePawn);

            Assert.IsTrue(result);
        }
    }
}

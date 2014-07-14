namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using KingSurvival.Interfaces;

    [TestClass]
    public class PawnsAndKingsFactoryTests
    {
        private readonly PawnsAndKingsFactory factory = new PawnsAndKingsFactory();

        [TestMethod]
        public void FactoryMakingPieceKingWithCreatePlayer1Piece()
        {
            IPiece piecePawn = factory.CreatePlayer1Piece();

            bool result = piecePawn.GetType() == typeof(PieceKing);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FactoryMakingPiecePawnWithCreatePlayer2Piece()
        {
            IPiece piecePawn = factory.CreatePlayer2Piece();

            bool result = piecePawn.GetType() == typeof(PiecePawn);

            Assert.IsTrue(result);
        }
    }
}

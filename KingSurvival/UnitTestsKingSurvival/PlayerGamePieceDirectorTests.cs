namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class PlayerGamePieceDirectorTests
    {
        [TestMethod]
        [TestCategory("InitializationTests")]
        public void PlayerGamePieceDirectorInitializationWithValidBuilder()
        {
            var builder = CreateBuilder();
            PlayerGamePieceDirector director = new PlayerGamePieceDirector(builder);
            director.CreateGamePiece();
            var piece = builder.GetPiece();

            bool result = piece.ID == 'K';

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("ExpectiongException")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerGamePieceDirectorInitializationWithNullValueInConstructor()
        {
            PlayerGamePieceDirector director = new PlayerGamePieceDirector(null);
        }

        private PlayersGamePieceBuilder CreateBuilder()
        {
            var factory = new PawnsAndKingsFactory();
            PlayersGamePieceBuilder builder = new Player1GamePieceBuilder(factory);

            return builder;
        }
    }
}

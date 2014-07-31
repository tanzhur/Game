namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Game.GameInitializer;

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
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlayerGamePieceDirectorInitializationWithNullValueInConstructor()
        {
            new PlayerGamePieceDirector(null);
        }

        private PlayersGamePieceBuilder CreateBuilder()
        {
            var factory = new PawnsAndKingsFactory();
            PlayersGamePieceBuilder builder = new Player1GamePieceBuilder(factory);

            return builder;
        }
    }
}

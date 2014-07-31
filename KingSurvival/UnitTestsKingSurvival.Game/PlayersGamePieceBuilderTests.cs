namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Game.GameInitializer;

    [TestClass]
    public class PlayersGamePieceBuilderTests
    {
        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestPlayersGamePieceBuilderInitializationTestingWithRealFactory()
        {
            var factory = new PawnsAndKingsFactory();
            PlayersGamePieceBuilder builder = new Player1GamePieceBuilder(factory);

            bool result = builder.GetType() == typeof(Player1GamePieceBuilder);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPlayersGamePieceBuilderInitializationTestingWithNullArgument()
        {
            new Player1GamePieceBuilder(null);
        }
    }
}

namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class PlayersGamePieceBuilderTests
    {
        [TestMethod]
        public void TestPlayersGamePieceBuilderInitializationTestingWithRealFactory()
        {
            var factory = new PawnsAndKingsFactory();
            PlayersGamePieceBuilder builder = new Player1GamePieceBuilder(factory);

            bool result = builder.GetType() == typeof(Player1GamePieceBuilder);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestPlayersGamePieceBuilderInitializationTestingWithNullArgument()
        {
            PlayersGamePieceBuilder builder = new Player1GamePieceBuilder(null);
        }
    }
}

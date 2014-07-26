
namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using System.IO;

    [TestClass]
    public class GameEngineTests
    {

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void GameEngineInitializationValidation()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            GameController testGameController = new GameController();
            var engine = new GameEngine(renderer, testGameController);

            bool result = engine.GetType() == typeof(GameEngine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void GameEngineInitializationWithInvalidInput()
        {
            GameController testGameController = new GameController();
            var engine = new GameEngine(null, testGameController);

            bool result = engine.GetType() == typeof(GameEngine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void GameEngineStartGameWithNullRenderer()
        {
            GameController testGameController = new GameController();
            var engine = new GameEngine(null, testGameController);

            engine.StartGame();
            bool result = engine.GetType() == typeof(GameEngine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void GameEngineStartGameWithNullController()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var engine = new GameEngine(renderer, null);

            engine.StartGame();
            bool result = engine.GetType() == typeof(GameEngine);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void GameEngineStartGameWithNullRendererAndController()
        {
            var engine = new GameEngine(null, null);

            engine.StartGame();
            bool result = engine.GetType() == typeof(GameEngine);

            Assert.IsTrue(result);
        }
    }
}

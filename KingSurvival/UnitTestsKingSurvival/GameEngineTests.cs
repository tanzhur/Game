
namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestMethod1()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            GameController testGameController = new GameController();
            var engine = new GameEngine(renderer, testGameController);


            bool result = engine.GetType() == typeof(GameEngine);

            Assert.IsTrue(result);
        }
    }
}

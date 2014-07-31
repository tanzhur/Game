namespace UnitTestsKingSurvival.ConsoleClient
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.ConsoleClient.Renderer;

    [TestClass]
    public class RendererConsoleTests
    {
        static TestConsole testConsole = new TestConsole();

        [TestCleanup]
        public void Cleanup() 
        {
            testConsole.ResetInputAndOutputToStandard();
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void InitializeRenderer()
        {
            new RendererConsole();
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void RenderMethodTest() 
        {
            var rendererConsole = new RendererConsole();
            char[,] testInputToRender = {{'1','2'}, {'3','4'}};

            testConsole.RedirectStandartOutputToConsole();
            rendererConsole.Render(testInputToRender, 0, 0);
            string answer = testConsole.GetWrittenContent();
            Assert.AreEqual("1234", answer);
        }
    }
}

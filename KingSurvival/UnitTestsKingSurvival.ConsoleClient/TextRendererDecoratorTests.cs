namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    
    [TestClass]
    public class TextRendererDecoratorTests
    {
        static TestConsole testConsole = new TestConsole();
        static TextRendererDecorator renderer;

        [TestCleanup]
        public void Cleanup() 
        {
            testConsole.ResetInputAndOutputToStandard();
        }

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TextRendererDecoratorInitializationTest() 
        {
            renderer = new TextRendererDecorator(new RendererConsole());
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void RenderTextMethodTest()
        {
            renderer = new TextRendererDecorator(new RendererConsole());
            testConsole.RedirectStandartOutputToConsole();
            renderer.RenderText("text", 2, 2);
            string answer = testConsole.GetWrittenContent();
            Assert.AreEqual("text", answer);
        }
    }
}

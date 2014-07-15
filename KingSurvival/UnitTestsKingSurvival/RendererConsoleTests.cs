namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class RendererConsoleTests
    {
        RendererConsole renderer = new RendererConsole(); 

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ClearScreenMethodTest()
        {
            renderer.ClearScreen();
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void RendererMethodTest()
        {
            char[,] testCharArr = {
                {'-', '-', '-', '-'},
                {'+', '+', '+', '+'},
                {'-', '-', '-', '-'},
                {'+', '+', '+', '+'},
                {'-', '-', '-', '-'},
                {'+', '+', '+', '+'},
                {'-', '-', '-', '-'},
                {'+', '+', 'K', '+'}
            };

            renderer.Render(testCharArr, 2, 2);
        }
    }
}

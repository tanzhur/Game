using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsKingSurvival
{
    [TestClass]
    public class TestConsoleTests
    {
        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void TestConsoleFunctionalityExample()
        {
            TestConsole testConsole = new TestConsole();

            // Here the input gets redirected. (if the testWrite function is never used the input is never redirected).
            testConsole.testWrite("12"); // Simulates a number typed by the user.
            int number = int.Parse(Console.ReadLine());
            Assert.AreEqual(12, number);

            testConsole.testWrite("Pesho"); // Simulates a string typed by the user.
            string name = Console.ReadLine();
            Assert.AreEqual("Pesho", name);

            // This redirects the input back to normal. Must be done 
            //after every use of the TestConsole!
            testConsole.ResetInputAndOutputToStandard(); 
        }
    }
}

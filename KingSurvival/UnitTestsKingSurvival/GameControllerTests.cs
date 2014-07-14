namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;
    using KingSurvival.Enums;
    using KingSurvival.Interfaces;

    [TestClass]
    public class GameControllerTests
    {
        GameController testGameController = new GameController();
        ICommand testCommand;
        TestConsole testConsole;

        /// <summary>
        /// Run this after every test.
        /// </summary>
        [TestCleanup]
        public void InitializeTests() 
        {
            testConsole.ResetInputAndOutputToStandard();   
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameControllerKURCommand()
        {
            testConsole = new TestConsole();
            testConsole.testWrite("KUR");
            this.testCommand = this.testGameController.GetCommand();

            Assert.AreEqual('K', testCommand.TargetID);
            Assert.AreEqual("UpRight", testCommand.Move.ToString());
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameControllerADLCommand()
        {
            testConsole = new TestConsole();
            testConsole.testWrite("ADL");
            this.testCommand = this.testGameController.GetCommand();

            Assert.AreEqual('A', testCommand.TargetID);
            Assert.AreEqual("DownLeft", testCommand.Move.ToString());
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameControllerKULCommand()
        {
            testConsole = new TestConsole();
            testConsole.testWrite("KUL");
            this.testCommand = this.testGameController.GetCommand();

            Assert.AreEqual('K', testCommand.TargetID);
            Assert.AreEqual("UpLeft", testCommand.Move.ToString());
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameControllerJDRCommand()
        {
            testConsole = new TestConsole();
            testConsole.testWrite("JDR");
            this.testCommand = this.testGameController.GetCommand();

            Assert.AreEqual('J', testCommand.TargetID);
            Assert.AreEqual("DownRight", testCommand.Move.ToString());
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameControllerWrongCommandTest()
        {
            testConsole = new TestConsole();
            testConsole.testWrite("Bll");
            this.testCommand = this.testGameController.GetCommand();

            Assert.AreEqual(null, testCommand);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameControllerCommadToLongTest2()
        {
            testConsole = new TestConsole();
            testConsole.testWrite("Bllasd");
            this.testCommand = this.testGameController.GetCommand();

            Assert.AreEqual(null, testCommand);
        }
    }
}

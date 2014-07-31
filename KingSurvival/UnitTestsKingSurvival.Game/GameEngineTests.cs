namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WindowsInput;
    using System.IO;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using KingSurvival.ConsoleClient.Controller;
    using KingSurvival.ConsoleClient.Renderer;

    using KingSurvival.Game;
    using KingSurvival.Game.Interfaces;
    using KingSurvival.Game.Enums;
    
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
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        [ExpectedException(typeof(NullReferenceException))]
        public void GameEngineStartGameWithNullRendererAndController()
        {
            var engine = new GameEngine(null, null);

            engine.StartGame();
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }
    }

    public class FakeController : IController
    {
        private static readonly Random getrandom = new Random();
        private char[] charList = new char[]{'K', 'A', 'B', 'C', 'D'};
        public IController controller;

        public FakeController()
        {
            this.controller = new GameController();
        }

        public ICommand GetCommand()
        {
            ICommand command = new Command(RandomPiece(), (Moves)getrandom.Next(0, 4));
            return command;
        }

        private char RandomPiece()
        {
            int index = getrandom.Next(0, 5);
            return charList[index];
        }

        public void PressAnyKey()
       {
           Console.Write(1);
       }
    }
}

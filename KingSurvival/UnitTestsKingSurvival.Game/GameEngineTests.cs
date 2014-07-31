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
        public void GameEngineStartGameShouldNotThrowException1()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException2()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException3()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException4()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException5()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException6()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException7()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException8()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException9()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException10()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException11()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException12()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException13()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException14()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException15()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException16()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException17()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException18()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException19()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException20()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException21()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException22()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException23()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException24()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException25()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException26()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException27()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException28()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException29()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException30()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException31()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException32()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException33()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException34()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException35()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException36()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException37()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException38()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException39()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException40()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException41()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException42()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException43()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException44()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException45()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException46()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException47()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException48()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException49()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void GameEngineStartGameShouldNotThrowException50()
        {
            var rendererConsole = new RendererConsole();
            var renderer = new GameRendererAdaptor(new TextRendererDecorator(rendererConsole));
            var controller = new FakeController();
            var engine = new GameEngine(renderer, controller);

            engine.StartGame();
            Assert.IsTrue(true);
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
        private char[] charList = new char[] { 'K', 'A', 'B', 'C', 'D' };
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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;
using KingSurvival.Enums;

namespace UnitTestsKingSurvival
{
    [TestClass]
    public class CommandTests
    {
        Moves downRight = Moves.DownRight;
        Moves downLeft = Moves.DownLeft;
        Moves upLeft = Moves.UpLeft;
        Moves upRight = Moves.UpRight;

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void TestCommandInitialization()
        {
            Command upLeftCommand = new Command('s', upLeft);
            Command upRightCommand = new Command('d', upRight);
            Command downLeftCommand = new Command('p', downLeft);
            Command downRightCommand = new Command('k', downRight);

            Assert.AreEqual('s', upLeftCommand.TargetID);
            Assert.AreEqual('d', upRightCommand.TargetID);
            Assert.AreEqual('p', downLeftCommand.TargetID);
            Assert.AreEqual('k', downRightCommand.TargetID);

            Assert.AreEqual("UpLeft", upLeftCommand.Move.ToString());
            Assert.AreEqual("UpRight", upRightCommand.Move.ToString());
            Assert.AreEqual("DownLeft", downLeftCommand.Move.ToString());
            Assert.AreEqual("DownRight", downRightCommand.Move.ToString());
        }
    }
}

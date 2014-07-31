namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Game.Logic;

    [TestClass]
    public class LogicPieceMoverTests
    {
        [TestMethod]
        [TestCategory("InitializationTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LogicPieceMoverSettingPiceMoverStrategyTestWithNullValue()
        {
            LogicPieceMover mover = new LogicPieceMover();
            mover.PieceMoverStrategy = null;
        }
    }
}

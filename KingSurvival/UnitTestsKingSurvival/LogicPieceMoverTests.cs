namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

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

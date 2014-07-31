namespace UnitTestsKingSurvival.Game
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Game.Common;

    [TestClass]
    public class GameValidatorTests
    {
        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckValueIsNullWithNullInput()
        {
            GameValidator.CheckValueIsNull(null, "property");
        }


        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckValueIsNullWithCorrectInput()
        {
            bool testRanCorrectly = true;
            GameValidator.CheckValueIsNull("test obj", "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckCharIsNotLetterWithCorrectCharInput()
        {
            bool testRanCorrectly = true;
            GameValidator.CheckCharIsNotLetter('A', "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatorTestForCheckCharIsNotLetterWithIncorrectCharInput()
        {
            GameValidator.CheckCharIsNotLetter('#', "property");
        }
    }
}

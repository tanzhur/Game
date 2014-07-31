namespace UnitTestsKingSurvival.ConsoleClient
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.ConsoleClient;

    [TestClass]
    public class ClientValidatorTests
    {
        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckValueIsNullWithNullInput()
        {
            ClientValidator.CheckValueIsNull(null, "property");
        }


        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckValueIsNullWithCorrectInput()
        {
            bool testRanCorrectly = true;
            ClientValidator.CheckValueIsNull("test obj", "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckCharIsNotLetterWithCorrectCharInput()
        {
            bool testRanCorrectly = true;
            ClientValidator.CheckCharIsNotLetter('A', "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatorTestForCheckCharIsNotLetterWithIncorrectCharInput()
        {
            ClientValidator.CheckCharIsNotLetter('#', "property");
        }
    }
}

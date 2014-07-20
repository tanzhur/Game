
namespace UnitTestsKingSurvival
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival;

    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckValueIsNullWithNullInput()
        {
            Validator.CheckValueIsNull(null, "property");
        }


        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckValueIsNullWithCorrectInput()
        {
            bool testRanCorrectly = true;
            Validator.CheckValueIsNull("test obj", "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckStringNullOrEmptyWithValuesInput()
        {
            bool testRanCorrectly = true;
            Validator.CheckStringNullOrEmpty("test string", "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckStringNullOrEmptyWithNullInput()
        {
            Validator.CheckStringNullOrEmpty(null, "property");
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckStringNullOrEmptyWithEmptyString()
        {
            Validator.CheckStringNullOrEmpty("", "property");
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckStringNullOrWhiteSpaceWithValuesInput()
        {
            bool testRanCorrectly = true;
            Validator.CheckStringNullOrWhiteSpace("test string", "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckStringNullOrWhiteSpaceWithNullInput()
        {
            Validator.CheckStringNullOrWhiteSpace(null, "property");
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidatorTestForCheckStringNullOrWhiteSpaceWithEmptyString()
        {
            Validator.CheckStringNullOrWhiteSpace(" ", "property");
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void ValidatorTestForCheckCharIsNotLetterWithCorrectCharInput()
        {
            bool testRanCorrectly = true;
            Validator.CheckCharIsNotLetter('A', "property");
            Assert.IsTrue(testRanCorrectly);
        }

        [TestMethod]
        [TestCategory("ExpectingExceptions")]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidatorTestForCheckCharIsNotLetterWithIncorrectCharInput()
        {
            Validator.CheckCharIsNotLetter('#', "property");
        }
    }
}

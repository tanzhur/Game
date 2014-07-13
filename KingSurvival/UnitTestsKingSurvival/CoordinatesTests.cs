using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace UnitTestsKingSurvival
{
    [TestClass]
    public class CoordinatesTests
    {
        Coordinates testCoordinate;

        [TestMethod]
        [TestCategory("InitializationTests")]
        public void CoordinatesInitializeTest()
        {
            testCoordinate = new Coordinates(1, 7); // Test edge cases.
            Assert.AreEqual(1, testCoordinate.X);
            Assert.AreEqual(7, testCoordinate.Y);
        }

        [TestMethod]
        [TestCategory("ExpectionExceptions")]
        [ExpectedException(typeof(ArgumentException), "Coordinates value must be between [0-7]")]
        public void NegativeCoordinates(){
            testCoordinate = new Coordinates(-5, 6);
        }

        [TestMethod]
        [TestCategory("ExpectionExceptions")]
        [ExpectedException(typeof(ArgumentException), "Coordinates value must be between [0-7]")]
        public void CoordinatesOverEight()
        {
            testCoordinate = new Coordinates(5, 11);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void CoordinatesEqualsTestWhenTrue()
        {
            testCoordinate = new Coordinates(); // Testing the (0, 0) case.
            bool answer = testCoordinate.Equals(new Coordinates());
            Assert.AreEqual(true, answer);
        }

        [TestMethod]
        [TestCategory("FunctionalityTests")]
        public void CoordinatesEqualsTestWhenFalse()
        {
            testCoordinate = new Coordinates(2, 3);
            bool answer = testCoordinate.Equals(new Coordinates(5, 5));
            Assert.AreEqual(false, answer);
        }
    }
}

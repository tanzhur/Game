using System;
using System.IO;

namespace UnitTestsKingSurvival
{
    /// <summary>
    /// This class redirects the standard input from the console to a 
    /// StringReader. Every time the method Console.ReadLine() is called 
    /// the input goes to a StringReader variable. This is done for testing purposes.
    /// </summary>
    public class TestConsole
    {
        private StringReader simulatedUserRead;

        /// <summary>
        /// Constructor.
        /// </summary>
        public TestConsole()
        {

        }

        /// <summary>
        /// This destructor closes the streams when all references to the class are gone!
        /// </summary>
        ~TestConsole()
        {
            if (this.simulatedUserRead != null)
            {
                this.simulatedUserRead.Close();
            }
        }

        /// <summary>
        /// This method redirects the result of the Console.ReadLine() function (and others.. but mainly that one)
        /// and it now reads from simulatedUserRead !
        /// </summary>
        private void RedirectStandartInput()
        {
            // Redirect standard Console input.
            Console.SetIn(simulatedUserRead);
        }

        /// <summary>
        /// This method resets the ConsleIn to the standard stream.
        /// </summary>
        public void ResetInputAndOutputToStandard()
        {
            // Reset console in.
            StreamReader standartIn = new StreamReader(Console.OpenStandardInput());
            standartIn.Dispose();
            Console.SetIn(standartIn);
        }

        /// <summary>
        /// This method tests one line of input from the fake user!
        /// When a Console.ReadLine() method is called the input gets flushed.
        /// </summary>
        /// <param name="input">The string we want to test with.</param>
        public void testWrite(string input)
        {
            if (this.simulatedUserRead != null)
            {
                this.simulatedUserRead.Close();
            }

            this.simulatedUserRead = new StringReader(input);
            RedirectStandartInput();
        }
    }
}

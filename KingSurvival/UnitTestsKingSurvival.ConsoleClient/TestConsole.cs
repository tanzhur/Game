namespace UnitTestsKingSurvival.ConsoleClient
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This class redirects the standard input from the console to a 
    /// StringReader. Every time the method Console.ReadLine() is called 
    /// the input goes to a StringReader variable. This is done for testing purposes.
    /// </summary>
    public class TestConsole
    {
        private StringReader simulatedUserRead;
        StringBuilder consoleContent;
        StringWriter simulatedWrite;

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

            if (this.simulatedWrite != null)
            {
                this.simulatedWrite.Close();
            }
        }

        /// <summary>
        /// This method redirects the result of the Console.ReadLine() function (and others.. but mainly that one)
        /// and it now reads from simulatedUserRead !
        /// </summary>
        private void RedirectStandartInput()
        {
            Console.SetIn(simulatedUserRead);
        }

        /// <summary>
        /// This method redirects the result of the Console.WriteLine() function and now
        /// it writes to the consoleContent StringBuilder.
        /// </summary>
        public void RedirectStandartOutputToConsole()
        {
            consoleContent = new StringBuilder();
            simulatedWrite = new StringWriter(consoleContent);
            Console.SetOut(simulatedWrite);
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

            // Reset console out.
            StreamWriter standartOut = new StreamWriter(Console.OpenStandardOutput());
            standartOut.AutoFlush = true;
            Console.SetOut(standartOut);
        }

        /// <summary>
        /// This method tests one line of input from the fake user!
        /// When a Console.ReadLine() method is called the input gets flushed.
        /// </summary>
        /// <param name="input">The string we want to test with.</param>
        public void TestWrite(string input)
        {
            if (this.simulatedUserRead != null)
            {
                this.simulatedUserRead.Close();
            }

            this.simulatedUserRead = new StringReader(input);
            RedirectStandartInput();
        }

        /// <summary>
        /// This method returns the information written by the Console.Write methods.
        /// </summary>
        /// <returns>answer as string.</returns>
        public string GetWrittenContent()
        {
            if (consoleContent == null)
            {
                throw new ArgumentNullException("The RedirectStandartOutput method must be called first.");
            }

            return this.consoleContent.ToString();
        }
    }
}

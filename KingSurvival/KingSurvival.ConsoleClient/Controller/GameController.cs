namespace KingSurvival.ConsoleClient.Controller
{
    using System;

    using KingSurvival.Game.Enums;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// ICommand generator via user inputs or reactions.
    /// </summary>
    public class GameController : IController
    {
        /// <summary>
        /// The up right command represented as a string.
        /// </summary>
        private const string CommandMoveUpRight = "UR";

        /// <summary>
        /// The up left command represented as a string.
        /// </summary>
        private const string CommandMoveUpLeft = "UL";

        /// <summary>
        /// The down right command represented as a string.
        /// </summary>
        private const string CommandMoveDownRight = "DR";

        /// <summary>
        /// The down left command represented as a string.
        /// </summary>
        private const string CommandMoveDownLeft = "DL";

        /// <summary>
        /// Gets a single ICommand from the user input or reaction.
        /// </summary>
        /// <returns>ICommand holding the target ID and the move to be executed.</returns>
        /// <seealso cref="ICommand"/>
        public ICommand GetCommand()
        {
            var currentCommandAsString = Console.ReadLine();

            if (string.IsNullOrEmpty(currentCommandAsString))
            {
                return null;
            }

            if (currentCommandAsString.Length != 3)
            {
                return null;
            }

            var currentCommandID = currentCommandAsString[0];

            var currentCommandMove = currentCommandAsString.Substring(1, 2);

            if (currentCommandMove == CommandMoveUpRight)
            {
                return new Command(currentCommandID, Moves.UpRight);
            }
            
            if (currentCommandMove == CommandMoveUpLeft)
            {
                return new Command(currentCommandID, Moves.UpLeft);
            }
            
            if (currentCommandMove == CommandMoveDownRight)
            {
                return new Command(currentCommandID, Moves.DownRight);
            }
            
            if (currentCommandMove == CommandMoveDownLeft)
            {
                return new Command(currentCommandID, Moves.DownLeft);
            }

            return null;
        }

        /// <summary>
        /// Waits until the user enters something via the input or reacts.
        /// </summary>
        public void PressAnyKey()
        {
            Console.ReadKey();
        }
    }
}

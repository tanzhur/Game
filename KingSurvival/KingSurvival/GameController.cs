namespace KingSurvival
{
    using System;

    using Enums;
    using Interfaces;

    /// <summary>
    /// ICommand generator via user inputs or reactions.
    /// </summary>
    public class GameController : IController
    {
        /// <summary>
        /// Gets a single ICommand from the user input or reaction.
        /// </summary>
        /// <returns>ICommand holding the target ID and the move to be executed.</returns>
        /// <seealso cref="ICommand"/>
        public ICommand GetCommand()
        {
            var currentCommandAsString = Console.ReadLine();

            if (currentCommandAsString.Length != 3)
            {
                return null;
            }

            var currentCommandID = currentCommandAsString[0];

            var currentCommandMove = currentCommandAsString.Substring(1, 2);

            if (currentCommandMove == GameConstants.CommandMoveUpRight)
            {
                return new Command(currentCommandID, Moves.UpRight);
            }
            else if (currentCommandMove == GameConstants.CommandMoveUpLeft)
            {
                return new Command(currentCommandID, Moves.UpLeft);
            }
            else if (currentCommandMove == GameConstants.CommandMoveDownRight)
            {
                return new Command(currentCommandID, Moves.DownRight);
            }
            else if (currentCommandMove == GameConstants.CommandMoveDownLeft)
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

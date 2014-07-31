namespace KingSurvival.ConsoleClient.Controller
{
    using System;

    using KingSurvival.Game.Enums;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// Object containing a char as a target ID and a move as a command action
    /// </summary>
    public class Command : ICommand
    {
        /// <summary>
        /// Holds the target ID of the command instance.
        /// </summary>
        private char targetID;

        /// <summary>
        /// Holds the Move of the command instance.
        /// </summary>
        private Moves move;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class for operation
        /// </summary>
        /// <param name="targetID">The ID to pass to the command constructor</param>
        /// <param name="move">The move to pass to the command constructor</param>
        public Command(char targetID, Moves move)
        {
            this.TargetID = targetID;
            this.Move = move;
        }

        /// <summary>
        /// Gets the target ID of the command instance.
        /// </summary>
        public char TargetID
        {
            get
            {
                return this.targetID;
            }

            private set
            {
                ClientValidator.CheckCharIsNotLetter(value, "Command target ID");

                this.targetID = value;
            }
        }

        /// <summary>
        /// Gets the move of the command instance.
        /// </summary>
        public Moves Move
        {
            get
            {
                return this.move;
            }

            private set
            {
                this.move = value;
            }
        }
    }
}

namespace KingSurvival.Game.GameObjects.Pieces
{
    using KingSurvival.Game.Common;
    using KingSurvival.Game.Enums;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// Game object controlled by the players and moved on the IGameBoard via IController.
    /// </summary>
    public abstract class Piece : IPiece, IObservableGamePiece, IMovableGamePiece
    {
        /// <summary>
        /// The ID by which the IPiece is recognized among others.
        /// </summary>
        private char id;

        /// <summary>
        /// The X-Y pair representing a point of the 2D space occupied by the IPiece.
        /// </summary>
        private ICoordinates coordinates;

        /// <summary>
        /// Event notifying all observers each time the IPiece moves.
        /// </summary>
        public event PieceMovedDelegate Moved;

        /// <summary>
        /// Gets or sets the ID by which the IPiece is recognized among others.
        /// </summary>
        public char ID
        {
            get
            {
                return this.id;
            }

            set
            {
                GameValidator.CheckCharIsNotLetter(value, "Piece ID");
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the X-Y pair representing a point of the 2D space occupied by the IPiece.
        /// </summary>
        public ICoordinates Coordinates
        {
            get
            {
                return this.coordinates;
            }

            set
            {
                GameValidator.CheckValueIsNull(value, "Piece coordinates");
                this.coordinates = value;
            }
        }

        /// <summary>
        /// Receives a Move to show if it is among the current allowed ones for the IPiece.
        /// </summary>
        /// <param name="move">Current Move that is going to be checked.</param>
        /// <returns>Answer whether the passed move is among the possible ones.</returns>
        public abstract bool IsValidMove(Moves move);

        /// <summary>
        /// Returns the future coordinates of the IPiece if it was to execute a current move.
        /// </summary>
        /// <param name="move">Current Move via which the future position of the IPiece is going to be calculated.</param>
        /// <returns>X-Y pair representing a point of the 2D space to be occupied by the IPiece.</returns>
        public abstract ICoordinates GetNewCoordinates(Moves move);

        /// <summary>
        /// Executes a move command by changing the current coordinates of the IPiece to the passed ones.
        /// </summary>
        /// <param name="coordinates">The new coordinates that the IPiece is going to occupy.</param>
        public void Move(ICoordinates coordinates) 
        {
            if (this.Moved != null)
            {
                this.Moved(this, coordinates);
            }

            this.Coordinates = coordinates;
        }
    }
}

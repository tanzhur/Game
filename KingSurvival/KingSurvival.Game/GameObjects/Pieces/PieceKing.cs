namespace KingSurvival.Game.GameObjects.Pieces
{
    using System.Linq;

    using KingSurvival.Game.Common;
    using KingSurvival.Game.Enums;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// King piece representing the main player one play figure.
    /// </summary>
    public class PieceKing : Piece, IPiece, IObservableGamePiece, IMovableGamePiece
    {
        /// <summary>
        /// A collection of all allowed moves for the king.
        /// </summary>
        private Moves[] allowedMoves;

        /// <summary>
        /// Initializes a new instance of the <see cref="PieceKing"/> class.
        /// </summary>
        public PieceKing()
        {
            this.allowedMoves = new Moves[] { Moves.DownLeft, Moves.DownRight, Moves.UpLeft, Moves.UpRight };
        }

        /// <summary>
        /// Receives a Move to show if it is among the current allowed ones for the king.
        /// </summary>
        /// <param name="move">Current Move that is going to be checked.</param>
        /// <returns>Answer whether the passed move is among the possible ones.</returns>
        public override bool IsValidMove(Moves move)
        {
            return this.allowedMoves.Contains(move);
        }

        /// <summary>
        /// Returns the future coordinates of the king if it was to execute a current move.
        /// </summary>
        /// <param name="move">Current Move via which the future position of the king is going to be calculated.</param>
        /// <returns>X-Y pair representing a point of the 2D space to be occupied by the king.</returns>
        public override ICoordinates GetNewCoordinates(Moves move)
        {
            if (move == Moves.UpLeft)
            {
                return new Coordinate(this.Coordinates.X - 1, this.Coordinates.Y - 1);
            }
            else if (move == Moves.UpRight)
            {
                return new Coordinate(this.Coordinates.X + 1, this.Coordinates.Y - 1);
            }
            else if (move == Moves.DownLeft)
            {
                return new Coordinate(this.Coordinates.X - 1, this.Coordinates.Y + 1);
            }
            else if (move == Moves.DownRight)
            {
                return new Coordinate(this.Coordinates.X + 1, this.Coordinates.Y + 1);
            }

            return null;
        }
    }
}

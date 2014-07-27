namespace KingSurvival
{
    using System.Linq;
    using Enums;
    using Interfaces;

    /// <summary>
    /// King piece representing the main player two play figure.
    /// </summary>
    public class PiecePawn : Piece, IPiece
    {
        /// <summary>
        /// A collection of all allowed moves for the pawn.
        /// </summary>
        private Moves[] allowedMoves;

        /// <summary>
        /// Initializes a new instance of the <see cref="PiecePawn"/> class.
        /// </summary>
        public PiecePawn()
        {
            this.allowedMoves = new Moves[] { Moves.DownLeft, Moves.DownRight };
        }

        /// <summary>
        /// Receives a Move to show if it is among the current allowed ones for the pawn.
        /// </summary>
        /// <param name="move">Current Move that is going to be checked.</param>
        /// <returns>Answer whether the passed move is among the possible ones.</returns>
        public override bool IsValidMove(Moves move)
        {
            return this.allowedMoves.Contains(move);
        }

        /// <summary>
        /// Returns the future coordinates of the pawn if it was to execute a current move.
        /// </summary>
        /// <param name="move">Current Move via which the future position of the pawn is going to be calculated.</param>
        /// <returns>X-Y pair representing a point of the 2D space to be occupied by the pawn.</returns>
        public override ICoordinates GetNewCoordinates(Moves move)
        {
            if (move == Moves.DownLeft)
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

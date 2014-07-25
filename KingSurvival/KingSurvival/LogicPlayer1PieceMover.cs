namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    /// <summary>
    /// Piece mover strategy that is specific for player 1.
    /// </summary>
    public class LogicPlayer1PieceMover : LogicPlayerPieceMoverBase
    {
        /// <summary>
        /// Finds a piece to move using logic for player one - adding score (moves) and searching in the first list of pieces
        /// </summary>
        /// <param name="command">The current command to look a piece for.</param>
        /// <param name="allPieces">All the pieces to search in</param>
        /// <param name="addScore">Information whether score must be added to player.</param>
        /// <returns>IPiece that can perform the current command</returns>
        public override IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces, out bool addScore)
        {
            addScore = false;

            foreach (var piece in allPieces[0])
            {
                if (command.TargetID == piece.ID && piece.IsValidMove(command.Move))
                {
                    addScore = true;
                    return piece;
                }
            }

            return null;
        }
    }
}
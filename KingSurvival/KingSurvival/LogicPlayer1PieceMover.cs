namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    /// <summary>
    /// Piece mover strategy that is specific for player 1.
    /// </summary>
    public class LogicPlayer1PieceMover : LogicPlayerPieceMoverBase
    {
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
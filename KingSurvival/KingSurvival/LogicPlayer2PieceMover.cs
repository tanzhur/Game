namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    // strategy design pattern
    public class LogicPlayer2PieceMover : LogicPlayerPieceMoverBase
    {
        public override IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces, out bool addScore)
        {
            addScore = false;

            foreach (var piece in allPieces[1])
            {
                if (command.TargetID == piece.ID && piece.IsValidMove(command.Move))
                {
                    return piece;
                }
            }

            return null;
        }
    }
}
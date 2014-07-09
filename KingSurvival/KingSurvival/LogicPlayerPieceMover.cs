namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    public class LogicPlayerPieceMover // strategy design pattern
    {
        private readonly int player;

        public LogicPlayerPieceMover(int player) //TODO: fix this fucker to be enum
        {
            this.player = player;
        }

        public virtual IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces)
        {
            foreach (var piece in allPieces[player])
            {
                if (piece.IsValidCommand(command))
                {
                    return piece;
                }
            }

            return null;
        }
    }
}
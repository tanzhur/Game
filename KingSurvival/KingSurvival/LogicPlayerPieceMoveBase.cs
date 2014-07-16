namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    // strategy design pattern
    public abstract class LogicPlayerPieceMoverBase
    {
        public abstract IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces, out bool addScore);
    }
}
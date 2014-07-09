namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    public class LogicPieceMover // strategy design pattern client
    {
        private LogicPlayerPieceMover pieceMoverStrategy;

        public LogicPieceMover() { }

        public LogicPlayerPieceMover PieceMoverStrategy
        {
            private get
            {
                return this.pieceMoverStrategy;
            }
            set
            {
                // CHECK DATA!
                this.pieceMoverStrategy = value;
            }
        }

        public IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces)
        {
            return this.pieceMoverStrategy.FindPieceToMove(command, allPieces);
        }
    }
}
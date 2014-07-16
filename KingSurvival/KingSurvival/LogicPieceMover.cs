namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    // strategy design pattern client
    public class LogicPieceMover
    {
        private LogicPlayerPieceMoverBase pieceMoverStrategy;

        public LogicPieceMover() { }

        public LogicPlayerPieceMoverBase PieceMoverStrategy
        {
            private get
            {
                return this.pieceMoverStrategy;
            }
            set
            {
                Validator.CheckValueIsNull(value, "Piece mover strategy can not be null or empty");
                this.pieceMoverStrategy = value;
            }
        }

        public IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces, out bool addScore)
        {
            return this.pieceMoverStrategy.FindPieceToMove(command, allPieces, out addScore);
        }
    }
}
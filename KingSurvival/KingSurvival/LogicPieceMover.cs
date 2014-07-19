namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    /// <summary>
    /// Handles moving pieces acording to predefined strategy.
    /// <para>Implemented with strategy pattern.</para>
    /// </summary>
    public class LogicPieceMover
    {
        private LogicPlayerPieceMoverBase pieceMoverStrategy;

        public LogicPieceMover() 
        { 
        }

        /// <summary>
        /// Strategy for the current piece.
        /// </summary>
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

        /// <summary>
        /// Find piece within the collectionq, that can implement the command.
        /// </summary>
        /// <param name="command">Command to be carried.</param>
        /// <param name="allPieces">Collection of pieces</param>
        /// <param name="addScore">Whether or not to count score for this piece.</param>
        /// <returns>Piece in the collection that can carry the command.</returns>
        public IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces, out bool addScore)
        {
            return this.pieceMoverStrategy.FindPieceToMove(command, allPieces, out addScore);
        }
    }
}
namespace KingSurvival
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Interfaces;

    /// <summary>
    /// Handles moving pieces according to predefined strategy.
    /// <para>Implemented with strategy pattern.</para>
    /// </summary>
    public class LogicPieceMover
    {
        /// <summary>
        /// Holds and instance of the logic to use when finding piece to move
        /// </summary>
        private LogicPlayerPieceMoverBase pieceMoverStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicPieceMover"/> class
        /// </summary>
        public LogicPieceMover() 
        { 
        }

        /// <summary>
        /// Gets or sets the strategy for the current piece.
        /// </summary>
        public LogicPlayerPieceMoverBase PieceMoverStrategy
        {
            [ExcludeFromCodeCoverage]
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
        /// Find piece within the collection, that can implement the command.
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
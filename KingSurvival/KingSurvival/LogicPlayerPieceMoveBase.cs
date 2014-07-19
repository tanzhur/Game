namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    /// <summary>
    /// Piece mover strategy that is to be carried by Logic Piece Mover
    /// <para>Implementation of strategy pattern</para>
    /// </summary>
    public abstract class LogicPlayerPieceMoverBase
    {
        /// <summary>
        /// Find piece within the collectionq, that can implement the command.
        /// </summary>
        /// <param name="command">Command to be carried.</param>
        /// <param name="allPieces">Collection of pieces</param>
        /// <param name="addScore">Whether or not to count score for this piece.</param>
        /// <returns>Piece in the collection that can carry the command.</returns>
        public abstract IPiece FindPieceToMove(ICommand command, IList<IList<IPiece>> allPieces, out bool addScore);
    }
}
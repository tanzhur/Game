namespace KingSurvival.Game.Interfaces
{
    using KingSurvival.Game.GameObjects.Pieces;

    /// <summary>
    /// Abstract factory holding the sole responsibility of creating instances of the various types of IPiece objects.
    /// </summary>
    public interface IGamePieceFactory 
    {
        /// <summary>
        /// Method for creating a piece used by player 1.
        /// </summary>
        /// <returns>IPiece implementing object.</returns>
        IPiece CreatePlayer1Piece();

        /// <summary>
        /// Method for creating a piece used by player 2.
        /// </summary>
        /// <returns>IPiece implementing object.</returns>
        IPiece CreatePlayer2Piece();
    }
}

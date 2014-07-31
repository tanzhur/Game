namespace KingSurvival.Game.GameInitializer
{
    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// Abstract factory holding the sole responsibility of creating instances of the various types of IPiece objects.
    /// </summary>
    public class PawnsAndKingsFactory : IGamePieceFactory 
    {
        /// <summary>
        /// Method for creating a piece used by player 1.
        /// </summary>
        /// <returns>IPiece implementing object.</returns>
        public IPiece CreatePlayer1Piece()
        {
            return new PieceKing();
        }

        /// <summary>
        /// Method for creating a piece used by player 2.
        /// </summary>
        /// <returns>IPiece implementing object.</returns>
        public IPiece CreatePlayer2Piece()
        {
            return new PiecePawn();
        }
    }
}

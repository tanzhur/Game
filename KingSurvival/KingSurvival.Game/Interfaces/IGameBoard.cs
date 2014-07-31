namespace KingSurvival.Game.Interfaces
{
    /// <summary>
    /// Interface for work with game-board
    /// </summary>
    public interface IGameBoard : IGamePieceObserver, IRenderable
    {
        /// <summary>
        /// Gets the  width of displayed game-board
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the height of displayed game-board
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the real size of playfield, without screen decorations
        /// </summary>
        int PlayfieldSize { get; }
    }
}

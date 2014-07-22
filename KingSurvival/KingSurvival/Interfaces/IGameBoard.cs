namespace KingSurvival.Interfaces
{
    /// <summary>
    /// Interface for work with gameboard
    /// </summary>
    public interface IGameBoard : IGamePieceObserver, IRenderable
    {
        /// <summary>
        /// Width of displayed gameboard
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Height of displayed gameboard
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Real size of playfield, without screen decorations
        /// </summary>
        int PlayfieldSize { get; }
    }
}

namespace KingSurvival.Game.Interfaces
{
    using KingSurvival.Game.Common;
    using KingSurvival.Game.GameObjects.Pieces;

    /// <summary>
    /// Interface for game piece movement notification
    /// <para>Implements observer design pattern.</para>
    /// </summary>
    public interface IGamePieceObserver
    {
        /// <summary>
        /// Notify when a game piece change her position.
        /// </summary>
        /// <param name="piece">The current piece to be moved</param>
        /// <param name="newPosition">The future position of the piece that is going to be moved</param>
        void Notify(IPiece piece, ICoordinates newPosition);
    }
}
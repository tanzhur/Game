namespace KingSurvival.Interfaces
{
    /// <summary>
    /// Interface for game piece movement notification
    /// <para>Implements observer design pattern.</para>
    /// </summary>
    public interface IGamePieceObserver
    {
        /// <summary>
        /// Notify when a game piece change her position.
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="newPosition"></param>
        void Notify(IPiece piece, ICoordinates newPosition);
    }
}
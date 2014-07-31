namespace KingSurvival.Game.Interfaces
{
    /// <summary>
    /// The moved event's delegate for the IPiece event.
    /// </summary>
    /// <param name="sender">The piece that has moved</param>
    /// <param name="oldCoordinates">The past coordinates of the piece used to delete it's old position</param>
    public delegate void PieceMovedDelegate(IPiece sender, ICoordinates oldCoordinates);

    /// <summary>
    /// Game object that can notify observers when it changes its position
    /// </summary>
    public interface IObservableGamePiece : IMovableGamePiece
    {
        /// <summary>
        /// Event notifying all observers each time the IPiece moves.
        /// </summary>
        event PieceMovedDelegate Moved;
    }
}

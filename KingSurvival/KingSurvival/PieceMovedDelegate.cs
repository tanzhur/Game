namespace KingSurvival
{
    using Interfaces;

    /// <summary>
    /// The moved event's delegate for the IPiece event.
    /// </summary>
    /// <param name="sender">The piece that has moved</param>
    /// <param name="oldCoordinates">The past coordinates of the piece used to delete it's old position</param>
    public delegate void PieceMovedDelegate(IPiece sender, ICoordinates oldCoordinates);
}

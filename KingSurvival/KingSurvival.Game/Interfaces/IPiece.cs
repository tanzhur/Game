namespace KingSurvival.Game.Interfaces
{
    using KingSurvival.Game.Common;
    using KingSurvival.Game.Enums;

    /// <summary>
    /// Game object holding information about it's ID and position via Coordinates
    /// </summary>
    public interface IPiece : IMovableGamePiece, IObservableGamePiece
    {
        /// <summary>
        /// Gets or sets the ID by which the IPiece is recognized among others.
        /// </summary>
        char ID { get; set; }

        /// <summary>
        /// Gets or sets the X-Y pair representing a point of the 2D space occupied by the IPiece.
        /// </summary>
        ICoordinates Coordinates { get; set; }
    }
}

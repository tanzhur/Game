namespace KingSurvival.Interfaces
{
    using System;

    /// <summary>
    /// A X-Y pair representing a point in the 2D space.
    /// </summary>
    public interface ICoordinates : IEquatable<ICoordinates>
    {
        /// <summary>
        /// Gets the left-right displacement of the point.
        /// </summary>
        int X { get; }

        /// <summary>
        /// Gets the up-down displacement of the point.
        /// </summary>
        int Y { get; }
    }
}

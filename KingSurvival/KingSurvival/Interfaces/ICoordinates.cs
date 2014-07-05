namespace KingSurvivalGame.Interfaces
{
    using System;

    public interface ICoordinates : IEquatable<ICoordinates>
    {
        int X { get; }

        int Y { get; }
    }
}

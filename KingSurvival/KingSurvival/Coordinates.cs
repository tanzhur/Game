namespace KingSurvival
{
    using System;

    using Interfaces;

    /// <summary>
    /// Represents a X-Y pair of a 2D point in space
    /// </summary>
    public struct Coordinates : ICoordinates, IEquatable<ICoordinates>
    {
        /// <summary>
        /// Holds the x coordinate
        /// </summary>
        private int x;

        /// <summary>
        /// Holds the y coordinate
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> struct
        /// </summary>
        /// <param name="x">The X coordinate</param>
        /// <param name="y">The Y coordinate</param>
        public Coordinates(int x = 0, int y = 0)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the X coordinate
        /// </summary>
        public int X
        {
            get
            {
                return this.x;
            }

            private set
            {
                Validator.CheckValueIsNull(value, "X Coordinates");
                this.x = value;
            }
        }

        /// <summary>
        /// Gets the Y coordinate
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }

            private set
            {
                Validator.CheckValueIsNull(value, "Y Coordinates");
                this.y = value;
            }
        }
        
        /// <summary>
        /// Compares the current instance with an object of type ICoordinates to show if they are the same
        /// </summary>
        /// <param name="other">The ICoordinates to compare with</param>
        /// <returns>If the two ICoordinates are equal</returns>
        public bool Equals(ICoordinates other)
        {
            bool isSame = this.X == other.X && this.Y == other.Y;
            return isSame;
        }
    }
}

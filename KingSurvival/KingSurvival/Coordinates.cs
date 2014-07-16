namespace KingSurvival
{
    using System;

    using Interfaces;

    public struct Coordinates : ICoordinates, IEquatable<ICoordinates>
    {
        private int x;
        private int y;

        // hack overloading constructor for struct ? Can be transformed into class
        public Coordinates(int x = 0, int y = 0)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

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
        
        public bool Equals(ICoordinates other)
        {
            bool isSame = this.X == other.X && this.Y == other.Y;
            return isSame;
        }
    }
}

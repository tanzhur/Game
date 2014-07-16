namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    using Enums;
    using Interfaces;

    public abstract class Piece : IPiece
    {
        private char id;
        private ICoordinates coordinates;

        public event PieceMovedDelegate Moved;

        public char ID
        {
            get
            {
                return this.id;
            }

            set
            {
                Validator.CheckCharIsNotLetter(value, "Piece ID");
                this.id = value;
            }
        }

        public ICoordinates Coordinates
        {
            get
            {
                return this.coordinates;
            }

            set
            {
                Validator.CheckValueIsNull(value, "Piece coordinates");
                this.coordinates = value;
            }
        }

        public abstract bool IsValidMove(Moves move);

        public abstract ICoordinates GetNewCoordinates(Moves move);

        public void Move(ICoordinates coordinates) 
        {
            if (this.Moved != null)
            {
                this.Moved(this, coordinates);
            }

            this.Coordinates = coordinates;
        }
    }
}

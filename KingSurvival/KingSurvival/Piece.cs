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

        // needed by observer patern (each figure holds a list of 
        // observers that it needs to notify everytime it moves)
        protected readonly IList<IGamePieceObserver> observers; 

        public Piece()
        {
            this.observers = new List<IGamePieceObserver>();
        }

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
        public abstract bool IsValidCommand(ICommand command);

        public abstract ICoordinates GetNewCoordinates(Moves move);

        public void Move(ICoordinates coordinates) 
        {
            if (Moved != null)
            {
                Moved(this, coordinates);
            }

            this.Coordinates = coordinates;
        }

        public event PieceMovedDelegate Moved;
    }
}

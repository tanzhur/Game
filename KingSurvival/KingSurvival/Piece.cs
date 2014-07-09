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
                if (char.IsLetter(value))
                {

                }
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
                this.coordinates = value;
            }
        }
        public abstract bool IsValidCommand(ICommand command);

        public abstract ICoordinates GetNewCoordinates(Moves move);

        public abstract void Move(ICoordinates coordinates); //have to call Notify Method Here on every move

        public void SubscribeToGamePieceObserver(IGamePieceObserver observer)
        {
            if (!this.observers.Contains(observer))
            {
                this.observers.Add(observer);
            }
        }

        public void UnSubscribeFromGamePieceObserver(IGamePieceObserver observer)
        {
            if (this.observers.Contains(observer))
            {
                this.observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (var observer in this.observers)
            {
                observer.Notify(this.ID, this.Coordinates);
            }
        }
    }
}

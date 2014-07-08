namespace KingSurvivalGame.Interfaces
{
    using KingSurvivalGame.Enums;

    public interface IPiece
    {
        char ID { get; set; }

        ICoordinates Coordinates { get; set; }

        bool IsValidCommand(ICommand command);

        ICoordinates GetNewCoordinates(Moves move);

        void Move(ICoordinates newCoordinates);

        // these 3 can be into a seperate interface (IObservableGamePiece)
        void SubscribeToGamePieceObserver(IGamePieceObserver observer);

        void UnSubscribeFromGamePieceObserver(IGamePieceObserver observer);

        void NotifyObservers();
    }
}

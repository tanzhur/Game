namespace KingSurvival.Interfaces
{
    // observer from behaviour design pattern
    public interface IGamePieceObserver
    {
        void Notify(IPiece piece, ICoordinates newPosition);
    }
}

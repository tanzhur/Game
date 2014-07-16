namespace KingSurvival.Interfaces
{
    using Enums;

    public interface IPiece
    {
        event PieceMovedDelegate Moved;

        char ID { get; set; }

        ICoordinates Coordinates { get; set; }

        bool IsValidMove(Moves move);

        ICoordinates GetNewCoordinates(Moves move);

        void Move(ICoordinates newCoordinates);
    }
}

namespace KingSurvival.Interfaces
{
    public interface IGamePieceFactory // abstract factory design pattern
    {
        IPiece CreatePlayer1Piece();

        IPiece CreatePlayer2Piece();
    }
}

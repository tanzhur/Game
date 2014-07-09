namespace KingSurvival.Interfaces
{
    // abstract factory design pattern
    public interface IGamePieceFactory 
    {
        IPiece CreatePlayer1Piece();

        IPiece CreatePlayer2Piece();
    }
}

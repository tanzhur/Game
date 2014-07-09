namespace KingSurvival
{
    using Interfaces;

    // abstract factory design pattern
    public class PawnsAndKingsFactory : IGamePieceFactory 
    {
        public IPiece CreatePlayer1Piece()
        {
            return new PieceKing();
        }

        public IPiece CreatePlayer2Piece()
        {
            return new PiecePawn();
        }
    }
}

namespace KingSurvival
{
    using Interfaces;

    public class PawnsAndKingsFactory : IGamePieceFactory // abstract factory design pattern
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

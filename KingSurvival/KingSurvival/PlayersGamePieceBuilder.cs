namespace KingSurvival
{
    using Interfaces;

    public abstract class PlayersGamePieceBuilder // builder design pattern - this is the base
    {
        protected readonly IGamePieceFactory Factory;

        public PlayersGamePieceBuilder(IGamePieceFactory factory)
        {
            this.Factory = factory; // check data
        }

        protected IPiece Piece;

        public abstract void CreatePiece();

        public abstract void SetPieceID();

        public abstract void SetPieceCoordinates();

        public abstract IPiece GetPiece();
    }
}

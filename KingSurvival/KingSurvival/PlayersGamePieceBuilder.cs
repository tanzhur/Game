namespace KingSurvival
{
    using Interfaces;

    // builder design pattern - this is the base
    public abstract class PlayersGamePieceBuilder 
    {
        protected readonly IGamePieceFactory Factory;

        public PlayersGamePieceBuilder(IGamePieceFactory factory)
        {
            Validator.CheckValueIsNull(factory, "Factory for the builder");
            this.Factory = factory;
        }

        protected IPiece Piece;

        public abstract void CreatePiece();

        public abstract void SetPieceID();

        public abstract void SetPieceCoordinates();

        public abstract IPiece GetPiece();
    }
}

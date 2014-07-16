namespace KingSurvival
{
    using Interfaces;

    // builder design pattern - this is the base
    public abstract class PlayersGamePieceBuilder 
    {
        protected readonly IGamePieceFactory Factory;
        private IPiece piece;

        public PlayersGamePieceBuilder(IGamePieceFactory factory)
        {
            Validator.CheckValueIsNull(factory, "Factory for the builder");
            this.Factory = factory;
        }

        protected IPiece Piece
        {
            get
            {
                return this.piece;
            }

            set
            {
                Validator.CheckValueIsNull(value, "Piece");

                this.piece = value;
            }
        }

        public abstract void CreatePiece();

        public abstract void SetPieceID();

        public abstract void SetPieceCoordinates();

        public abstract IPiece GetPiece();
    }
}

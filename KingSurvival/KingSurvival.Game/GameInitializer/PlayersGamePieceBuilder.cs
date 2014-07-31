namespace KingSurvival.Game.GameInitializer
{
    using KingSurvival.Game.Common;
    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// Abstract class for creating builders of game pieces via abstract factory for game pieces.
    /// <para>This is builder design pattern base.</para>
    /// </summary>
    public abstract class PlayersGamePieceBuilder 
    {
        /// <summary>
        /// The factory to be used when creating pieces.
        /// </summary>
        protected readonly IGamePieceFactory Factory;

        /// <summary>
        /// The IPiece that is being built and returned in the end.
        /// </summary>
        private IPiece piece;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersGamePieceBuilder"/> class using abstract factory.
        /// </summary>
        /// <param name="factory">The factory to use for creation of pieces</param>
        public PlayersGamePieceBuilder(IGamePieceFactory factory)
        {
            GameValidator.CheckValueIsNull(factory, "Factory for the builder");
            this.Factory = factory;
        }

        /// <summary>
        /// Gets or sets the IPiece that is going to be built and returned.
        /// </summary>
        protected IPiece Piece
        {
            get
            {
                return this.piece;
            }

            set
            {
                GameValidator.CheckValueIsNull(value, "Piece");

                this.piece = value;
            }
        }

        /// <summary>
        /// Creates the piece by receiving it from the abstract factory.
        /// </summary>
        public abstract void CreatePiece();

        /// <summary>
        /// Creates the Piece ID by using the game constants class.
        /// </summary>
        public abstract void SetPieceID();

        /// <summary>
        /// Creates the Piece coordinates by using the game constants class.
        /// </summary>
        public abstract void SetPieceCoordinates();

        /// <summary>
        /// Returns the ready piece.
        /// </summary>
        /// <returns>IPiece with correct name and coordinates.</returns>
        public abstract IPiece GetPiece();
    }
}

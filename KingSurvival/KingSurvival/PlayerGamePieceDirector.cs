namespace KingSurvival
{
    using Interfaces;

    /// <summary>
    /// Game pieces builder for creating pieces for player two via abstract factory for game pieces.
    /// <para>This is builder design pattern director.</para>
    /// </summary>
    public class PlayerGamePieceDirector 
    {
        /// <summary>
        /// The builder used by the director.
        /// </summary>
        private readonly PlayersGamePieceBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerGamePieceDirector"/> class using abstract factory.
        /// </summary>
        /// <param name="builder">The builder to use while calling methods.</param>
        public PlayerGamePieceDirector(PlayersGamePieceBuilder builder)
        {
            Validator.CheckValueIsNull(builder, "Builder for the director");
            this.builder = builder; 
        }

        /// <summary>
        /// Holds the sequence of the methods to be called on the builder.
        /// </summary>
        public void CreateGamePiece()
        {
            this.builder.CreatePiece();
            this.builder.SetPieceID();
            this.builder.SetPieceCoordinates();
        }

        /// <summary>
        /// Returns the ready piece.
        /// </summary>
        /// <returns>IPiece with correct name and coordinates.</returns>
        public IPiece GetGamePiece()
        {
            return this.builder.GetPiece();
        }
    }
}

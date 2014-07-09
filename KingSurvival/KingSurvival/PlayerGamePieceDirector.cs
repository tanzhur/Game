namespace KingSurvival
{
    using Interfaces;

    // builder design pattern this is the director
    public class PlayerGamePieceDirector 
    {
        private readonly PlayersGamePieceBuilder builder;

        public PlayerGamePieceDirector(PlayersGamePieceBuilder builder)
        {
            Validator.CheckValueIsNull(builder, "Builder for the director");
            this.builder = builder; 
        }

        public void CreateGamePiece()
        {
            this.builder.CreatePiece();
            this.builder.SetPieceID();
            this.builder.SetPieceCoordinates();
        }

        public IPiece GetGamePiece()
        {
            return this.builder.GetPiece();
        }
    }
}

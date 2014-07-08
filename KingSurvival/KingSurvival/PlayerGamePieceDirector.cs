namespace KingSurvival
{
    using Interfaces;

    public class PlayerGamePieceDirector // builder design pattern this is the director
    {
        private readonly PlayersGamePieceBuilder builder;

        public PlayerGamePieceDirector(PlayersGamePieceBuilder builder)
        {
            this.builder = builder; // check data
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

namespace KingSurvival
{
    using System.Collections.Generic;

    using Interfaces;

    // facade design pattern
    public class PlayersAllGamePiecesCreator 
    {
        public PlayersAllGamePiecesCreator()
        {
        }

        public IList<IList<IPiece>> CreateGamePieces()
        {
            // main factory
            var factory = new PawnsAndKingsFactory();

            // player 1
            var player1PieceBuilder = new Player1GamePieceBuilder(factory);
            var player1PieceCreator = new PlayerGamePieceDirector(player1PieceBuilder);

            var player1GamePieces = new List<IPiece>();

            // 1 piece
            player1PieceCreator.CreateGamePiece();
            player1GamePieces.Add(player1PieceCreator.GetGamePiece());

            // player 2
            var player2PieceBuilder = new Player2GamePieceBuilder(factory);
            var player2PieceCreator = new PlayerGamePieceDirector(player2PieceBuilder);

            var player2GamePieces = new List<IPiece>();

            // 4 pieces
            player2PieceCreator.CreateGamePiece();
            player2GamePieces.Add(player2PieceCreator.GetGamePiece());
            player2PieceCreator.CreateGamePiece();
            player2GamePieces.Add(player2PieceCreator.GetGamePiece());
            player2PieceCreator.CreateGamePiece();
            player2GamePieces.Add(player2PieceCreator.GetGamePiece());
            player2PieceCreator.CreateGamePiece();
            player2GamePieces.Add(player2PieceCreator.GetGamePiece());

            var listToReturn = new List<IList<IPiece>>();

            listToReturn.Add(player1GamePieces);
            listToReturn.Add(player2GamePieces);

            return listToReturn;
        }
    }
}

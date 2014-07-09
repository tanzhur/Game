namespace KingSurvival
{
    using Interfaces;

    // builder design pattern - knows how and which properties to set on player one pieces
    public class Player2GamePieceBuilder : PlayersGamePieceBuilder
    {
        private readonly char[] PieceID = new char[] { GameConstants.PawnAName, GameConstants.PawnBName, 
                                              GameConstants.PawnCName, GameConstants.PawnDName };

        private readonly int[] startPositionsX = new int[] {GameConstants.PawnAStartCol, GameConstants.PawnBStartCol, 
                                                  GameConstants.PawnCStartCol, GameConstants.PawnDStartCol};

        private readonly int[] startPositionsY = new int[] {GameConstants.PawnAStartRow, GameConstants.PawnBStartRow, 
                                                  GameConstants.PawnCStartRow, GameConstants.PawnDStartRow};

        private int pieceIndex;

        public Player2GamePieceBuilder(IGamePieceFactory factory)
            : base(factory)
        {
            this.pieceIndex = 0;
        }

        public override void CreatePiece()
        {
            this.Piece = this.Factory.CreatePlayer2Piece();
        }

        public override void SetPieceID()
        {
            this.Piece.ID = this.PieceID[this.pieceIndex];
        }

        public override void SetPieceCoordinates()
        {
            this.Piece.Coordinates = new Coordinates(this.startPositionsX[this.pieceIndex],
                                                     this.startPositionsY[this.pieceIndex]);
        }

        public override IPiece GetPiece()
        {
            // getting ready for the next piece only after we take this one
            this.pieceIndex++;
            if (this.pieceIndex >= startPositionsX.Length)
            {
                this.pieceIndex = 0;
            }

            return this.Piece;
        }
    }
}

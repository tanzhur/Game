﻿namespace KingSurvival
{
    using Interfaces;

    // builder design pattern - knows how and which properties to set on player one pieces
    public class Player1GamePieceBuilder : PlayersGamePieceBuilder
    {
        private readonly char[] PieceID = new char[] { GameConstants.KingName };

        private readonly int[] startPositionsX = new int[] { GameConstants.KingStartCol };

        private readonly int[] startPositionsY = new int[] { GameConstants.KingStartRow };

        private int pieceIndex;

        public Player1GamePieceBuilder(IGamePieceFactory factory)
            : base(factory)
        {
            this.pieceIndex = 0;
        }

        public override void CreatePiece()
        {
            this.Piece = this.Factory.CreatePlayer1Piece();
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
            // protect the data here - if index out of range ??
            this.pieceIndex++;
            if (this.pieceIndex >= startPositionsX.Length)
            {
                this.pieceIndex = 0;
            }

            return this.Piece;
        }
    }
}

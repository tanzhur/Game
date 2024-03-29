﻿namespace KingSurvival.Game.GameInitializer
{
    using KingSurvival.Game.Common;
    using KingSurvival.Game.GameObjects.Pieces;
    using KingSurvival.Game.Interfaces;

    /// <summary>
    /// Game pieces builder for creating pieces for player two via abstract factory for game pieces.
    /// <para>This is builder design pattern.</para>
    /// </summary>
    public class Player2GamePieceBuilder : PlayersGamePieceBuilder
    {
        /// <summary>
        /// Array of all the IDs of the player one pieces.
        /// </summary>
        private readonly char[] pieceID = new char[] 
        { 
            GameConstants.PawnAName, 
            GameConstants.PawnBName, 
            GameConstants.PawnCName, 
            GameConstants.PawnDName 
        };

        /// <summary>
        /// Array of all the X coordinates of the player one pieces.
        /// </summary>
        private readonly int[] startPositionsX = new int[] 
        {
            GameConstants.PawnAStartCol,
            GameConstants.PawnBStartCol, 
            GameConstants.PawnCStartCol, 
            GameConstants.PawnDStartCol
        };

        /// <summary>
        /// Array of all the Y coordinates of the player one pieces.
        /// </summary>
        private readonly int[] startPositionsY = new int[] 
        {
            GameConstants.PawnAStartRow,
            GameConstants.PawnBStartRow, 
            GameConstants.PawnCStartRow,
            GameConstants.PawnDStartRow
        };

        /// <summary>
        /// Index of current ID and coordinates to use.
        /// </summary>
        private int pieceIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player2GamePieceBuilder"/> class using abstract factory.
        /// </summary>
        /// <param name="factory">The factory to use for creation of pieces</param>
        public Player2GamePieceBuilder(IGamePieceFactory factory)
            : base(factory)
        {
            this.pieceIndex = 0;
        }

        /// <summary>
        /// Creates the piece by receiving it from the abstract factory.
        /// </summary>
        public override void CreatePiece()
        {
            this.Piece = this.Factory.CreatePlayer2Piece();
        }

        /// <summary>
        /// Creates the Piece ID by using the game constants class.
        /// </summary>
        public override void SetPieceID()
        {
            this.Piece.ID = this.pieceID[this.pieceIndex];
        }

        /// <summary>
        /// Creates the Piece coordinates by using the game constants class.
        /// </summary>
        public override void SetPieceCoordinates()
        {
            this.Piece.Coordinates = new Coordinate(
                                     this.startPositionsX[this.pieceIndex],
                                     this.startPositionsY[this.pieceIndex]);
        }

        /// <summary>
        /// Returns the ready piece.
        /// </summary>
        /// <returns>IPiece with correct name and coordinates.</returns>
        public override IPiece GetPiece()
        {
            // getting ready for the next piece only after we take this one
            this.pieceIndex++;
            if (this.pieceIndex >= this.startPositionsX.Length)
            {
                this.pieceIndex = 0;
            }

            return this.Piece;
        }
    }
}

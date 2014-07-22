namespace KingSurvival
{
    using System;
    using Interfaces;

    /// <summary>
    /// GameBoard class holds board sizes and ralation between screen and logical coordinates.
    /// <para>Part of observer design pattern.</para>
    /// </summary>
    public class GameBoard : IGameBoard, IRenderable, IGamePieceObserver
    {
        // Real game size, without screen decorations
        private const int TotalPlayfieldSize = 8;

        // Offsets displayed gameboard on screen
        private const int TopBoardOffset = 2;
        private const int LeftBoardOffset = 4;

        // Size of display board place, including space
        private const int DisplayBoardPlaceSize = 2;

        private static GameBoard instance;

        /// <summary>
        /// Holds gamefield without game pieces
        /// </summary>
        private readonly char[,] originalGameFieldObjects = 
        {    
            { ' ', ' ', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ' },
            { ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ' },
            { '0', ' ', '|', ' ', '+', ' ', '-', ' ', '+', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
            { '1', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
            { '2', ' ', '|', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
            { '3', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
            { '4', ' ', '|', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
            { '5', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
            { '6', ' ', '|', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
            { '7', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
            { ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ' }
        };

        /// <summary>
        /// Holds gamefield with game pieces
        /// </summary>
        private char[,] currentGameFieldObjects;

        /// <summary>
        /// Gameboard constructor with initialized gameboard
        /// </summary>
        public GameBoard()
        {
            this.currentGameFieldObjects = new char[,] 
            {    
                { ' ', ' ', ' ', ' ', '0', ' ', '1', ' ', '2', ' ', '3', ' ', '4', ' ', '5', ' ', '6', ' ', '7', ' ', ' ' },
                { ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ' },
                { '0', ' ', '|', ' ', 'A', ' ', '-', ' ', 'B', ' ', '-', ' ', 'C', ' ', '–', ' ', 'D', ' ', '-', ' ', '|' },
                { '1', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
                { '2', ' ', '|', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
                { '3', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
                { '4', ' ', '|', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
                { '5', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
                { '6', ' ', '|', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '-', ' ', '|' },
                { '7', ' ', '|', ' ', '-', ' ', '+', ' ', '–', ' ', 'K', ' ', '–', ' ', '+', ' ', '–', ' ', '+', ' ', '|' },
                { ' ', ' ', ' ', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', ' ' }
            };
        }

        public static GameBoard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameBoard();
                }

                return instance;
            }
        }

        /// <summary>
        /// Width of displayed gameboard
        /// </summary>
        public int Width
        {
            get
            {
                return this.originalGameFieldObjects.GetLength(1);
            }
        }

        /// <summary>
        /// Height of displayed gameboard
        /// </summary>
        public int Height
        {
            get
            {
                return this.originalGameFieldObjects.GetLength(0);
            }
        }

        /// <summary>
        /// Real size of playfield, without screen decorations
        /// </summary>
        public int PlayfieldSize
        {
            get
            {
                return TotalPlayfieldSize;
            }
        }

        /// <summary>
        /// Image of the current gameboard
        /// </summary>
        /// <returns>Char array with gameboard and game pieces</returns>
        public char[,] Image
        {
            get
            {
                var matrixToReturn = new char[this.currentGameFieldObjects.GetLength(0), this.currentGameFieldObjects.GetLength(1)];

                for (int row = 0; row < this.currentGameFieldObjects.GetLength(0); row++)
                {
                    for (int col = 0; col < this.currentGameFieldObjects.GetLength(1); col++)
                    {
                        matrixToReturn[row, col] = this.currentGameFieldObjects[row, col];
                    }
                }

                return matrixToReturn;
            }
        }

        /// <summary>
        /// Notify when a game piece change her position.
        /// Calculates relation between screen and logical coordinates.
        /// </summary>
        /// <param name="piece">Game piece who change her position</param>
        /// <param name="newPosition">The new position on gameboard</param>
        public void Notify(IPiece piece, ICoordinates newPosition)
        {
            int oldDisplayPositionRow = TopBoardOffset + piece.Coordinates.Y;
            int oldDisplayPositionCol = LeftBoardOffset + (DisplayBoardPlaceSize * piece.Coordinates.X);

            this.currentGameFieldObjects[oldDisplayPositionRow, oldDisplayPositionCol]
                = this.originalGameFieldObjects[oldDisplayPositionRow, oldDisplayPositionCol];

            int newDisplayPositionRow = TopBoardOffset + newPosition.Y;
            int newDisplayPositionCol = LeftBoardOffset + (DisplayBoardPlaceSize * newPosition.X);

            this.currentGameFieldObjects[newDisplayPositionRow, newDisplayPositionCol] = piece.ID;
        }
    }
}

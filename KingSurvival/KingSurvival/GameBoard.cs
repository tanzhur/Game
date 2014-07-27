namespace KingSurvival
{
    using Interfaces;

    /// <summary>
    /// GameBoard class holds board sizes and relation between screen and logical coordinates.
    /// <para>Part of observer design pattern.</para>
    /// </summary>
    public class GameBoard : IGameBoard, IRenderable, IGamePieceObserver
    {
        /// <summary>
        /// Real game size, without screen decorations.
        /// </summary>
        private const int TotalPlayfieldSize = 8;

        /// <summary>
        /// Top Offset displayed game board on screen.
        /// </summary>
        private const int TopBoardOffset = 2;

        /// <summary>
        /// Left Offset displayed game board on screen.
        /// </summary>
        private const int LeftBoardOffset = 4;

        /// <summary>
        /// Size of display board place, including space.
        /// </summary>
        private const int DisplayBoardPlaceSize = 2;

        /// <summary>
        /// The only instance kept of the game board object.
        /// </summary>
        private static GameBoard instance;

        /// <summary>
        /// Holds game field without game pieces
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
        /// Holds game field with game pieces
        /// </summary>
        private char[,] currentGameFieldObjects;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard"/> class with initialized game board
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

        /// <summary>
        /// Gets the only instance of the game board
        /// </summary>
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
        /// Gets the width of displayed game board
        /// </summary>
        public int Width
        {
            get
            {
                return this.originalGameFieldObjects.GetLength(1);
            }
        }

        /// <summary>
        /// Gets the height of displayed game board
        /// </summary>
        public int Height
        {
            get
            {
                return this.originalGameFieldObjects.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the real size of play field, without screen decorations
        /// </summary>
        public int PlayfieldSize
        {
            get
            {
                return TotalPlayfieldSize;
            }
        }

        /// <summary>
        /// Gets the image of the current game board
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
        /// <param name="newPosition">The new position on game board</param>
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

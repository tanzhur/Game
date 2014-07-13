namespace KingSurvival
{
    using System;

    using Interfaces;

    public class GameBoard : IGameBoard, IRenderable, IGamePieceObserver
    {
        private readonly char[,] OriginalGameFieldObjects = 
        {    
            {' ',' ',' ',' ','0',' ','1',' ','2',' ','3',' ','4',' ','5',' ','6',' ','7',' ',' '},
            {' ',' ',' ','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',' '},
            {'0',' ','|',' ','+',' ','-',' ','+',' ','-',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'1',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {'2',' ','|',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'3',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {'4',' ','|',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'5',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {'6',' ','|',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'7',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {' ',' ',' ','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',' '}
        };

        private const int TotalPlayfieldSize = 8;
        private const int TopBoardOffset = 2;
        private const int LeftBoardOffset = 4;
        private const int DisplayBoardPlaceSize = 2;

        private char[,] currentGameFieldObjects;

        private static GameBoard instance;

        private GameBoard()
        {
            this.currentGameFieldObjects = new char[,] {    
            {' ',' ',' ',' ','0',' ','1',' ','2',' ','3',' ','4',' ','5',' ','6',' ','7',' ',' '},
            {' ',' ',' ','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',' '},
            {'0',' ','|',' ','A',' ','-',' ','B',' ','-',' ','C',' ','–',' ','D',' ','-',' ','|'},
            {'1',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {'2',' ','|',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'3',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {'4',' ','|',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'5',' ','|',' ','-',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {'6',' ','|',' ','+',' ','–',' ','+',' ','–',' ','+',' ','–',' ','+',' ','-',' ','|'},
            {'7',' ','|',' ','-',' ','+',' ','–',' ','K',' ','–',' ','+',' ','–',' ','+',' ','|'},
            {' ',' ',' ','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-',' '}
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

        public int Width
        {
            get
            {
                return this.OriginalGameFieldObjects.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return this.OriginalGameFieldObjects.GetLength(0);
            }
        }

        public int PlayfieldSize
        {
            get
            {
                return TotalPlayfieldSize;
            }
        }

        public void Notify(char id, ICoordinates newPosition)
        {
            int oldRow;
            int oldCol;
            int newDisplayPositionRow;
            int newDisplayPositionCol;

            if (this.TryFindIDOnBoard(id, out oldRow, out oldCol))
            {
                this.currentGameFieldObjects[oldRow, oldCol] = this.OriginalGameFieldObjects[oldRow, oldCol];

                newDisplayPositionRow = TopBoardOffset + newPosition.Y;
                newDisplayPositionCol = LeftBoardOffset + DisplayBoardPlaceSize * newPosition.X;

                this.currentGameFieldObjects[newDisplayPositionRow, newDisplayPositionCol] = id;
            }
        }

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

        private bool TryFindIDOnBoard(char id, out int oldRow, out int oldCol)
        {
            for (int row = 0; row < this.currentGameFieldObjects.GetLength(0); row++)
            {
                for (int col = 0; col < this.currentGameFieldObjects.GetLength(1); col++)
                {
                    if (currentGameFieldObjects[row, col] == id)
                    {
                        oldRow = row;
                        oldCol = col;
                        return true;
                    }
                }
            }
            oldRow = -1;
            oldCol = -1;

            return false;
        }
    }
}

namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    public class GameBoard : IRenderable
    {
        /// <summary>
        /// Holds the default view of the game board
        /// </summary>
        private const char[,] OriginalGameFieldObjects = 
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

        // the gameBoard play area begins at position [2,4] not [0,0]
        public const int OffsetRows = 2;
        public const int OffsetCols = 4;

        public const int PlayfieldSize = 8;

        public GameBoard()
        {
        }
        
        public Coordinate GetTopLeft()
        {
            return new Coordinate(0, 0);
        }

        public char[,] GetImage()
        {
            return OriginalGameFieldObjects;
        }
    }
}

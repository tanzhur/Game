namespace KingSurvival
{
    /// <summary>
    /// Static class holding all the constants for the game.
    /// </summary>
    public static class GameConstants
    {
        /// <summary>
        /// Holds information about the first pawn's starting Row/X coordinate.
        /// </summary>
        public const int PawnAStartRow = 0;

        /// <summary>
        /// Holds information about the first pawn's starting Col/Y coordinate.
        /// </summary>
        public const int PawnAStartCol = 0;

        /// <summary>
        /// Holds information about the first pawn's name.
        /// </summary>
        public const char PawnAName = 'A';

        /// <summary>
        /// Holds information about the second pawn's starting Row/X coordinate.
        /// </summary>
        public const int PawnBStartRow = 0;

        /// <summary>
        /// Holds information about the second pawn's starting Col/Y coordinate.
        /// </summary>
        public const int PawnBStartCol = 2;

        /// <summary>
        /// Holds information about the second pawn's name.
        /// </summary>
        public const char PawnBName = 'B';

        /// <summary>
        /// Holds information about the third pawn's starting Row/X coordinate.
        /// </summary>
        public const int PawnCStartRow = 0;

        /// <summary>
        /// Holds information about the third pawn's starting Col/Y coordinate.
        /// </summary>
        public const int PawnCStartCol = 4;

        /// <summary>
        /// Holds information about the third pawn's name.
        /// </summary>
        public const char PawnCName = 'C';

        /// <summary>
        /// Holds information about the fourth pawn's starting Row/X coordinate.
        /// </summary>
        public const int PawnDStartRow = 0;

        /// <summary>
        /// Holds information about the fourth pawn's starting Col/Y coordinate.
        /// </summary>
        public const int PawnDStartCol = 6;

        /// <summary>
        /// Holds information about the fourth pawn's name.
        /// </summary>
        public const char PawnDName = 'D';

        /// <summary>
        /// Holds information about the king's starting Row/X coordinate.
        /// </summary>
        public const int KingStartRow = 7;

        /// <summary>
        /// Holds information about the king's starting Col/Y coordinate.
        /// </summary>
        public const int KingStartCol = 3;

        /// <summary>
        /// Holds information about the king's name.
        /// </summary>
        public const char KingName = 'K';

        /// <summary>
        /// Holds information about the time the messages stay on screen before cleared.
        /// </summary>
        public const int MessageShowTimeMilliseconds = 2000;

        /// <summary>
        /// Holds information about the position at which the message should be rendered.
        /// </summary>
        public const int MessageToPlayerOffset = 2;

        /// <summary>
        /// The Illegal move message shown to the player.
        /// </summary>
        public const string IllegalMove = "Illegal move!";

        /// <summary>
        /// The player one turn message shown to the player.
        /// </summary>
        public const string Player1Turn = "King's turn: ";

        /// <summary>
        /// The player two turn message shown to the player.
        /// </summary>
        public const string Player2Turn = "Pawns' turn: ";

        /// <summary>
        /// The blank message shown to the player.
        /// </summary>
        public const string BlankMessage = "                                ";

        /// <summary>
        /// The king wins in X turns string format.
        /// </summary>
        public const string KingWinsInXTurns = "King wins in {0} turns.";

        /// <summary>
        /// The king loses message shown to the player.
        /// </summary>
        public const string KingLooses = "King loses.";

        /// <summary>
        /// The up right command represented as a string.
        /// </summary>
        public const string CommandMoveUpRight = "UR";

        /// <summary>
        /// The up left command represented as a string.
        /// </summary>
        public const string CommandMoveUpLeft = "UL";

        /// <summary>
        /// The down right command represented as a string.
        /// </summary>
        public const string CommandMoveDownRight = "DR";

        /// <summary>
        /// The down left command represented as a string.
        /// </summary>
        public const string CommandMoveDownLeft = "DL";
    }
}

namespace KingSurvival
{
    public static class GameConstants
    {
        public const int PawnAStartRow = 0;
        public const int PawnAStartCol = 0;
        public const char PawnAName = 'A';

        public const int PawnBStartRow = 0;
        public const int PawnBStartCol = 2;
        public const char PawnBName = 'B';

        public const int PawnCStartRow = 0;
        public const int PawnCStartCol = 4;
        public const char PawnCName = 'C';

        public const int PawnDStartRow = 0;
        public const int PawnDStartCol = 6;
        public const char PawnDName = 'D';

        public const int KingStartRow = 7;
        public const int KingStartCol = 3;
        public const char KingName = 'K';

        public const int MessageShowTimeMilliseconds = 2000;

        public const int MessageToPlayerOffset = 2;
        public const string IllegalMove = "Illegal move!";
        public const string Player1Turn = "King's turn: ";
        public const string Player2Turn = "Pawns' turn: ";
        public const string BlankMessage = "                                ";

        public const string KingWinsInXTurns = "King wins in {0} turns.";
        public const string KingLooses = "King loses.";

        public const string CommandMoveUpRight = "UR";
        public const string CommandMoveUpLeft = "UL";
        public const string CommandMoveDownRight = "DR";
        public const string CommandMoveDownLeft = "DL";
    }
}

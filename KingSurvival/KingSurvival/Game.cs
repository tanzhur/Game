namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    internal class Game
    {
        private const int ScreenRows = 50;
        private const int ScreenCols = 50;

        private const int PawnAStartRow = 0;
        private const int PawnAStartColumn = 0;
        private const int PawnBStartRow = 0;
        private const int PawnBStartColumn = 2;
        private const int PawnCStartRow = 0;
        private const int PawnCStartColumn = 4;
        private const int PawnDStartRow = 0;
        private const int PawnDStartColumn = 6;
        private const int KingStartRow = 7;
        private const int KingStartColumn = 3;

        internal static void Main()
        {
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight = 60;

            var kingInitialPosition = new Coordinate(KingStartRow, KingStartColumn);
            var pawnAInitialPosition = new Coordinate(PawnAStartRow, PawnAStartColumn);
            var pawnBInitialPosition = new Coordinate(PawnBStartRow, PawnBStartColumn);
            var pawnCInitialPosition = new Coordinate(PawnCStartRow, PawnCStartColumn);
            var pawnDInitialPosition = new Coordinate(PawnDStartRow, PawnDStartColumn);


            GamePiece pawnA = new Pawn(pawnAInitialPosition, new char[,] { { 'A' } });
            GamePiece pawnB = new Pawn(pawnBInitialPosition, new char[,] { { 'B' } });
            GamePiece pawnC = new Pawn(pawnCInitialPosition, new char[,] { { 'C' } });
            GamePiece pawnD = new Pawn(pawnDInitialPosition, new char[,] { { 'D' } });

            GamePiece king = new King(kingInitialPosition, new char[,] { { 'K' } });

            var list = new List<GamePiece> { pawnA, pawnB, pawnC, pawnD, king };
            var renderer = new ConsoleRenderer(ScreenRows, ScreenCols);

            var engine = new Engine(renderer, list);
            engine.Run();
        }
    }
}

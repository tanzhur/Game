using System;

namespace KingSurvival
{
    class Game
    {
        private const int ScreenRows = 50;
        private const int ScreenCols = 50;

        public static void Main()
        {
            Console.BufferWidth = Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowHeight = 60;

            var renderer = new ConsoleRenderer(ScreenRows, ScreenCols);

            var engine = new Engine(renderer);
            engine.Run();
        }
    }
}

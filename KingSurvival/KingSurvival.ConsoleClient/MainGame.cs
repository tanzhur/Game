namespace KingSurvival.ConsoleClient
{
    /// <summary>
    /// Entry point of KingSurvival
    /// </summary>
    public static class MainGame
    {
        /// <summary>
        /// Main entry point of the whole program
        /// </summary>
        public static void Main()
        {
           var game = new Game();
           game.Start();
        }
    }
}

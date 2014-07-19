namespace KingSurvival
{
    /// <summary>
    /// Initialize & Start KingSurvival
    /// </summary>
    public class Game
    {
        private readonly GameEngine engine;

        public Game()
        {
            var decoratedRenderer = new TextRendererDecorator(new RendererConsole());
            var renderer = new GameRendererAdaptor(decoratedRenderer);

            var controller = new GameController();

            this.engine = new GameEngine(renderer, controller);
        }

        /// <summary>
        /// Start the game.
        /// </summary>
        public void Start()
        {
            this.engine.StartGame();
        }
    }
}

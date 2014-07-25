namespace KingSurvival
{
    /// <summary>
    /// Initialize and Start KingSurvival
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The instance of the game engine used by the Game class.
        /// </summary>
        private readonly GameEngine engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class for operation
        /// </summary>
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

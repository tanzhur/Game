namespace KingSurvival
{
    public class Game
    {
        private readonly GameEngine engine;

        public Game()
        {
            var renderer = new GameRenderer(null); // fix this null mother fucker
            var controller = new GameController();

            this.engine = new GameEngine(renderer, controller);
        }

        public void Start()
        {
            this.engine.StartGame();
        }
    }
}

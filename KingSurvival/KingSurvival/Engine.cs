namespace KingSurvival
{
    using System.Collections.Generic;

    class Engine
    {
        private IRenderer renderer;

        private List<GamePiece> pieces;

        public Engine(IRenderer renderer, List<GamePiece> pieces)
        {
            this.renderer = renderer;
            this.pieces = pieces;
        }

        public void Run()
        {
            while (true)
            {



            }
        }
    }
}


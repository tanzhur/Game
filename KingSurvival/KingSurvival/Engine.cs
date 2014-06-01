namespace KingSurvival
{
    class Engine
    {
        private IRenderer renderer;

        public Engine(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Run()
        {
            while (true)
            {

                renderer.RenderAll();

            }
        }
    }
}


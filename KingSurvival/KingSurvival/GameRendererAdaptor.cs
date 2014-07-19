namespace KingSurvival
{
    using Interfaces;

    /// <summary>
    /// GameRendererAdaptor class
    /// Adapter design pattern.
    /// </summary>
    public class GameRendererAdaptor : IRenderer
    {
        private readonly TextRendererDecoratorBase textRendererDecorator;

        public GameRendererAdaptor(TextRendererDecoratorBase textRendererDecorator)
        {
            Validator.CheckValueIsNull(textRendererDecorator, "Text renderer decorator for the game engine");
            this.textRendererDecorator = textRendererDecorator;
        }

        public void Render(IRenderable target, ICoordinates leftTop)
        {
            this.textRendererDecorator.Render(target.Image, leftTop.X, leftTop.Y);
        }

        public void RenderText(string text, ICoordinates leftTop)
        {
            this.textRendererDecorator.RenderText(text, leftTop.X, leftTop.Y);
        }

        public void ClearScreen()
        {
            this.textRendererDecorator.ClearScreen();
        }
    }
}

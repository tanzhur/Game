namespace KingSurvival
{
    using Interfaces;

    /// <summary>
    /// GameRendererAdaptor class
    /// Adapter design pattern.
    /// </summary>
    public class GameRendererAdaptor : IRenderer
    {
        /// <summary>
        /// Holds the base text renderer decorator which to use when redirecting the methods implemented due to the interface.
        /// </summary>
        private readonly TextRendererDecoratorBase textRendererDecorator;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRendererAdaptor"/> class
        /// </summary>
        /// <param name="textRendererDecorator">The base text renderer decorator to use.</param>
        public GameRendererAdaptor(TextRendererDecoratorBase textRendererDecorator)
        {
            Validator.CheckValueIsNull(textRendererDecorator, "Text renderer decorator for the game engine");
            this.textRendererDecorator = textRendererDecorator;
        }

        /// <summary>
        /// Visualizes the image on the screen.
        /// </summary>
        /// <param name="target">The image to visualize on the screen.</param>
        /// <param name="leftTop">The coordinates at which to visualize the image.</param>
        public void Render(IRenderable target, ICoordinates leftTop)
        {
            this.textRendererDecorator.Render(target.Image, leftTop.X, leftTop.Y);
        }

        /// <summary>
        /// Visualizes the text on the screen.
        /// </summary>
        /// <param name="text">The text to visualize on the screen.</param>
        /// <param name="leftTop">The coordinates at which to visualize the text.</param>
        public void RenderText(string text, ICoordinates leftTop)
        {
            this.textRendererDecorator.RenderText(text, leftTop.X, leftTop.Y);
        }

        /// <summary>
        /// Cleares the screen.
        /// </summary>
        public void ClearScreen()
        {
            this.textRendererDecorator.ClearScreen();
        }
    }
}

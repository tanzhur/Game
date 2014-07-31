namespace KingSurvival.ConsoleClient.Renderer
{
    /// <summary>
    /// Abstract class used for rendering 2D arrays of chars and text with set offset. Uses RendererBase.
    /// <remarks>Decorator Design Pattern - base decorator</remarks>
    /// </summary>
    public abstract class TextRendererDecoratorBase : RendererBase
    {
        /// <summary>
        /// The renderer base that is used to divert the render commands to.
        /// </summary>
        private readonly RendererBase rendererBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRendererDecoratorBase"/> class using RendererBase.
        /// </summary>
        /// <param name="rendererBase">The renderer base to use</param>
        protected TextRendererDecoratorBase(RendererBase rendererBase)
        {
            ClientValidator.CheckValueIsNull(rendererBase, "Base renderer");
            this.rendererBase = rendererBase;
        }

        /// <summary>
        /// Renders object represented by 2D char array starting at specific offsets.
        /// </summary>
        /// <param name="objectToRender">The object to render.</param>
        /// <param name="offsetX">The x offset</param>
        /// <param name="offsetY">The y offset</param>
        public override void Render(char[,] objectToRender, int offsetX, int offsetY)
        {
            this.rendererBase.Render(objectToRender, offsetX, offsetY);
        }

        /// <summary>
        /// Removes everything from the screen.
        /// </summary>
        public override void ClearScreen()
        {
            this.rendererBase.ClearScreen();
        }

        /// <summary>
        /// Renders text starting at specific offsets.
        /// </summary>
        /// <param name="text">The text to render.</param>
        /// <param name="initialLeft">The x offset</param>
        /// <param name="initialTop">The y offset</param>
        public abstract void RenderText(string text, int initialLeft, int initialTop);
    }
}

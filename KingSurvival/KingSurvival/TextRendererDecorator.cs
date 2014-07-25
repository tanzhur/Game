namespace KingSurvival
{
    /// <summary>
    /// TextRendererDecorator class
    /// Decorator Design Pattern
    /// </summary>
    public class TextRendererDecorator : TextRendererDecoratorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextRendererDecorator"/> class using RendererBase.
        /// </summary>
        /// <param name="rendererBase">The renderer base to use</param>
        public TextRendererDecorator(RendererBase rendererBase) 
            : base(rendererBase)
        {
        }

        /// <summary>
        /// Draws text the console starting at specific offset.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="offsetX">The x offset.</param>
        /// <param name="offsetY">The y offset.</param>
        public override void RenderText(string text, int offsetX, int offsetY)
        {
            var textAsMatrix = new char[1, text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                textAsMatrix[0, i] = text[i];
            }

            this.Render(textAsMatrix, offsetX, offsetY);
        }
    }
}
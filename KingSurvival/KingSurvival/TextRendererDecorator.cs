namespace KingSurvival
{
    /// <summary>
    /// TextRendererDecorator class
    /// Decorator Design Pattern
    /// </summary>
    public class TextRendererDecorator : TextRendererDecoratorBase
    {
        public TextRendererDecorator(RendererBase rendererBase) 
            : base(rendererBase)
        {
        }

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
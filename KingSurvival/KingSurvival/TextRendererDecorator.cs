namespace KingSurvival
{
    public class TextRendererDecorator : TextRendererDecoratorBase // decorator design pattern concrete decorator
    {
        public TextRendererDecorator(RendererBase rendererBase) 
            : base(rendererBase)
        {
        }

        public override void RenderText(string text, int offsetX, int offsetY)
        {
            char[,] textAsMatrix = new char[1, text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                textAsMatrix[0, i] = text[i];
            }

            this.Render(textAsMatrix, offsetX, offsetY);
        }
    }
}

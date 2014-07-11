namespace KingSurvival
{
    public abstract class TextRendererDecoratorBase : RendererPlain // decorator design pattern decorator base
    {
        private readonly RendererPlain rendererBase;

        protected TextRendererDecoratorBase(RendererPlain rendererBase)
        {
            Validator.CheckValueIsNull(rendererBase, "Base renderer");
            this.rendererBase = rendererBase;
        }

        public override void Render(char[,] objectToRender, int offsetX, int offsetY)
        {
            this.rendererBase.Render(objectToRender, offsetX, offsetY);
        }

        public override void ClearScreen()
        {
            this.rendererBase.ClearScreen();
        }

        public abstract void RenderText(string text, int initialLeft, int initialTop);
    }
}

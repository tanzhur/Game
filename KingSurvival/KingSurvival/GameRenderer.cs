namespace KingSurvivalGame
{
    using KingSurvivalGame.Interfaces;
    public class GameRenderer : TextRendererDecorator, IRenderer
    {
        public GameRenderer(RendererBase renderBase)
            : base(renderBase) { }

        public void Render(IRenderable target, ICoordinates leftTop)
        {
            base.Render(target.Image, leftTop.X, leftTop.Y);
        }

        public void RenderText(string text, ICoordinates leftTop)
        {
            base.RenderText(text, leftTop.X, leftTop.Y);
        }
    }
}

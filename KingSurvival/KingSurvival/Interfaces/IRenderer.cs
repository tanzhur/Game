namespace KingSurvival.Interfaces
{
    /// <summary>
    /// An interface for a Renderer.
    /// </summary>
    public interface IRenderer
    {
        void Render(IRenderable target, ICoordinates leftTop);

        void RenderText(string text, ICoordinates leftTop);

        void ClearScreen();
    }
}

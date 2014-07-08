namespace KingSurvival.Interfaces
{
    public interface IRenderer
    {
        void Render(IRenderable target, ICoordinates leftTop);

        void RenderText(string text, ICoordinates leftTop);

        void ClearScreen();
    }
}

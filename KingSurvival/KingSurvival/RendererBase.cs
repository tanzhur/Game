namespace KingSurvivalGame
{
    public abstract class RendererBase // decorator design pattern component base
    {
        public abstract void Render(char[,] objectToRender, int initialLeft, int initialTop);

        public abstract void ClearScreen();
    }
}

namespace KingSurvival
{
    public abstract class RendererPlain // decorator design pattern component base
    {
        public abstract void Render(char[,] objectToRender, int initialLeft, int initialTop);

        public abstract void ClearScreen();
    }
}

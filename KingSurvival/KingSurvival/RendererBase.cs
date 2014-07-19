namespace KingSurvival
{
    /// <summary>
    /// A RendererBase Class using Decorator Design Pattern.
    /// This is the component base class.
    /// </summary>
    public abstract class RendererBase
    {
        public abstract void Render(char[,] objectToRender, int initialLeft, int initialTop);

        public abstract void ClearScreen();
    }
}

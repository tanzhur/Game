namespace KingSurvival
{
    /// <summary>
    /// A RendererBase Class to be used by the Decorator Design Pattern.
    /// This is the component base class.
    /// </summary>
    public abstract class RendererBase
    {
        /// <summary>
        /// Draws and 2D array of chars to the console starting at specific offset.
        /// </summary>
        /// <param name="objectToRender">The 2D array of chars to draw.</param>
        /// <param name="offsetX">The x offset.</param>
        /// <param name="offsetY">The y offset.</param>
        public abstract void Render(char[,] objectToRender, int initialLeft, int initialTop);

        /// <summary>
        /// Removes everything from the console.
        /// </summary>
        public abstract void ClearScreen();
    }
}

namespace KingSurvival.ConsoleClient.Renderer
{
    /// <summary>
    /// Abstract class used for rendering 2D arrays of chars with set offset.
    /// <remarks>Decorator Design pattern - base component.</remarks>
    /// </summary>
    public abstract class RendererBase
    {
        /// <summary>
        /// Draws and 2D array of chars to the console starting at specific offset.
        /// </summary>
        /// <param name="objectToRender">The 2D array of chars to draw.</param>
        /// <param name="initialLeft">The x offset</param>
        /// <param name="initialTop">The y offset.</param>
        public abstract void Render(char[,] objectToRender, int initialLeft, int initialTop);

        /// <summary>
        /// Removes everything from the console.
        /// </summary>
        public abstract void ClearScreen();
    }
}

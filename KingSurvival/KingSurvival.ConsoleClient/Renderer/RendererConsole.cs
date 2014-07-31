namespace KingSurvival.ConsoleClient.Renderer
{
    using System;

    /// <summary>
    /// Class used for rendering 2D arrays of chars with set offset.
    /// <remarks>Decorator Design pattern - concrete component.</remarks>
    /// </summary>
    public class RendererConsole : RendererBase
    {
        /// <summary>
        /// Draws and 2D array of chars to the console starting at specific offset.
        /// </summary>
        /// <param name="objectToRender">The 2D array of chars to draw.</param>
        /// <param name="offsetX">The x offset.</param>
        /// <param name="offsetY">The y offset.</param>
        public override void Render(char[,] objectToRender, int offsetX, int offsetY)
        {
            for (int row = 0; row < objectToRender.GetLength(0); row++)
            {
                Console.SetCursorPosition(offsetX, offsetY + row);

                for (int column = 0; column < objectToRender.GetLength(1); column++)
                {
                    Console.Write(objectToRender[row, column]);
                }
            }
        }

        /// <summary>
        /// Removes everything from the console.
        /// </summary>
        public override void ClearScreen()
        {
            Console.Clear();
        }
    }
}

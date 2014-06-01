namespace KingSurvival
{
    using System;

    /// <summary>
    /// Renderer that uses the System.Console class to draw on the console
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        // Singleton design pattern implementation
        private static ConsoleRenderer instance;

        private ConsoleRenderer()
        {
        }

        /// <summary>
        /// Returns the only instance of this class
        /// </summary>
        public static ConsoleRenderer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleRenderer();
                }

                return instance;
            }
        }

        /// <summary>
        /// Draws an object on the System.Console by givven an matrix of char elements and initial top left position
        /// </summary>
        /// <param name="image">2 Dimensional array representing the image to render</param>
        /// <param name="left">The leftmost position from wich to begin the drawing</param>
        /// <param name="top">the topmost position from wich to begin the drawing</param>
        public void Render(char[,] image, int left, int top)
        {
            for (int row = 0; row < image.GetLength(0); row++)
            {
                // on every row the cursor is put back to the initial left position
                // for each of the rows the cursor is moved down once
                Console.SetCursorPosition(left, top - row);

                for (int col = 0; col < image.GetLength(1); col++)
                {
                    Console.Write(image[row,col]);
                }
            }
        }
    }
}

namespace KingSurvival
{
    using System;

    /// <summary>
    /// RendererConsole Class
    /// Decorator Design pattern - concrete component.
    /// </summary>
    public class RendererConsole : RendererBase
    {
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

        public override void ClearScreen()
        {
            Console.Clear();
        }
    }
}

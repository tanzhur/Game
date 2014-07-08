namespace KingSurvivalGame
{
    using System;

    public class RendererConsole : RendererBase // decorator design pattern concrete component
    {
        public override void Render(char[,] objectToRender, int offsetX, int offsetY)
        {
            for (int row = 0; row < objectToRender.GetLength(0); row++)
            {
                Console.SetCursorPosition(offsetX, offsetY + row);

                for (int col = 0; col < objectToRender.GetLength(1); col++)
                {
                    Console.Write(objectToRender[row,col]);
                }
            }
        }

        public override void ClearScreen()
        {
            Console.Clear();
        }
    }
}

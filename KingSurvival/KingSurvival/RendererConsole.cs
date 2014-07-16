namespace KingSurvival
{
    using System;

    public class RendererConsole : RendererBase // decorator design pattern concrete component
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

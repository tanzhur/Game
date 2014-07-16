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
                    char sign = objectToRender[row, column];
                    Console.ForegroundColor = PickColor(sign);
                    Console.Write(sign);
                    Console.ResetColor();
                }
            }
        }

        public override void ClearScreen()
        {
            Console.Clear();
        }

        private ConsoleColor PickColor(char sign)
        {
            // TODO: More Colors will be added.
            ConsoleColor color;
            switch (sign)
            {
                case 'K':
                    color = ConsoleColor.DarkGreen;
                    break;
                default:
                    color = ConsoleColor.Gray;
                    break;
            }

            return color;
        }
    }
}

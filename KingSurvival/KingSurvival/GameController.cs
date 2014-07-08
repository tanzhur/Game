namespace KingSurvival
{
    using System;

    using Enums;
    using Interfaces;

    public class GameController : IController
    {
        public ICommand GetCommand()
        {
            var currentCommandAsString = Console.ReadLine();

            if (currentCommandAsString.Length != 3)
            {
                return null;
            }

            var currentCommandID = currentCommandAsString[0];

            var currentCommandMove = currentCommandAsString.Substring(1, 2);

            if (currentCommandMove == "UR")
            {
                return new Command(currentCommandID, Moves.UpRight);
            }
            else if (currentCommandMove == "UL")
            {
                return new Command(currentCommandID, Moves.UpLeft);
            }
            else if (currentCommandMove == "DR")
            {
                return new Command(currentCommandID, Moves.DownRight);
            }
            else if (currentCommandMove == "DL")
            {
                return new Command(currentCommandID, Moves.DownLeft);
            }

            return null;
        }

        public void PressAnyKey()
        {
            Console.ReadKey();
        }
    }
}

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

            if (currentCommandMove == GameConstants.CommandMoveUpRight)
            {
                return new Command(currentCommandID, Moves.UpRight);
            }
            else if (currentCommandMove == GameConstants.CommandMoveUpLeft)
            {
                return new Command(currentCommandID, Moves.UpLeft);
            }
            else if (currentCommandMove == GameConstants.CommandMoveDownRight)
            {
                return new Command(currentCommandID, Moves.DownRight);
            }
            else if (currentCommandMove == GameConstants.CommandMoveDownLeft)
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

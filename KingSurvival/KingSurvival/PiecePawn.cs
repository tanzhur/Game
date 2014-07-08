namespace KingSurvivalGame
{
    using KingSurvivalGame.Enums;
    using KingSurvivalGame.Interfaces;

    public class PiecePawn : Piece, IPiece
    {
        public override bool IsValidCommand(ICommand command)
        {
            if (this.ID != command.TargetID)
            {
                return false;
            }

            if (command.Move == Moves.DownLeft || command.Move == Moves.DownRight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override ICoordinates GetNewCoordinates(Moves move)
        {
            if (move == Moves.DownLeft)
            {
                return new Coordinates(this.Coordinates.X - 1, this.Coordinates.Y + 1);
            }
            else if (move == Moves.DownRight)
            {
                return new Coordinates(this.Coordinates.X + 1, this.Coordinates.Y + 1);
            }

            return null;
        }

        public override void Move(ICoordinates coordinates)
        {
            this.Coordinates = new Coordinates(coordinates.X, coordinates.Y);

            this.NotifyObservers();
        }
    }
}

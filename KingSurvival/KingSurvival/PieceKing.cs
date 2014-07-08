namespace KingSurvival
{
    using Enums;
    using Interfaces;

    public class PieceKing : Piece, IPiece
    {
        public override bool IsValidCommand(ICommand command)
        {
            if (this.ID != command.TargetID)
            {
                return false;
            }

            if (command.Move == Moves.DownLeft || command.Move == Moves.DownRight
                 || command.Move == Moves.UpLeft || command.Move == Moves.UpRight)
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
            if (move == Moves.UpLeft)
            {
                return new Coordinates(this.Coordinates.X - 1, this.Coordinates.Y - 1);
            }
            else if (move == Moves.UpRight)
            {
                return new Coordinates(this.Coordinates.X + 1, this.Coordinates.Y - 1);
            }
            else if (move == Moves.DownLeft)
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

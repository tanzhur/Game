namespace KingSurvival
{
    using System.Linq;

    using Enums;
    using Interfaces;

    public class PieceKing : Piece, IPiece
    {
        private Moves[] allowedMoves;

        public PieceKing()
        {
            this.allowedMoves = new Moves[] { Moves.DownLeft, Moves.DownRight, Moves.UpLeft, Moves.UpRight };
        }
        public override bool IsValidMove(Moves move)
        {
            return this.allowedMoves.Contains(move);
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
    }
}

namespace KingSurvival
{
    using System.Linq;

    using Enums;
    using Interfaces;

    public class PiecePawn : Piece, IPiece
    {
        private Moves[] allowedMoves;

        public PiecePawn()
        {
            this.allowedMoves = new Moves[] { Moves.DownLeft, Moves.DownRight };
        }

        public override bool IsValidMove(Moves move)
        {
            return this.allowedMoves.Contains(move);
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
    }
}

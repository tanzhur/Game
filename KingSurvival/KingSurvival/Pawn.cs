using System;

namespace KingSurvival
{
    public sealed class Pawn : GamePiece, IMovable
    {
        public Pawn(Coordinate initialPosition, char[,] image)
            : base(initialPosition, image)
        {
        }

        public override void Update()
        {
            this.Move();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}

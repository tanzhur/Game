using System;

namespace KingSurvival
{
    public sealed class King : GamePiece, IMovable
    {
        public King(Coordinate initialPosition, char[,] image)
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

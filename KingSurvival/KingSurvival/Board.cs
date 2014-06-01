using System;

namespace KingSurvival
{
    public class Board : GamePiece
    {
        public Board(Coordinate currentPosition, char[,] image)
            : base(currentPosition, image)
        {
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}

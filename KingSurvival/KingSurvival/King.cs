using System;

namespace KingSurvival
{
    public sealed class King : GamePiece, IMovable
    {
        public King(Coordinate initialPosition, char[,] image)
            : base(initialPosition, image)
        {
        }

        // az promenih metodite doly za da se kompilira - preimenuvah i metoda move - trqbva da vrushta buleva stoinost.
        // ideqta s update spored men trqbva da q obsudim - v tazi igra ne e prilojima spored men // dzhenko
        public override void Update()
        {

            this.TryMove(Moves.DownLeft);
        }

        public bool TryMove(Moves move)
        {
            throw new NotImplementedException();
        }
    }
}

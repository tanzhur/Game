namespace KingSurvival
{
    public abstract class GamePiece : IRenderable
    {
        private Coordinate currentPosition;
        private char[,] image;

        protected GamePiece(Coordinate currentPosition, char[,] image)
        {
            this.CurrentPosition = currentPosition;
            this.Image = image;
        }

        public char[,] Image
        {
            get
            {
                return this.image;
            }

            private set
            {
                this.image = value;

            }
        }

        protected Coordinate CurrentPosition
        {
            get { return this.currentPosition; }
            private set { this.currentPosition = value; }
        }


        public abstract void Update();

        public Coordinate GetTopLeft()
        {
            return this.CurrentPosition;
        }

        public char[,] GetImage()
        {
            return this.Image;
        }
    }
}

namespace KingSurvival
{
    public struct Coordinate
    {
        private int row;
        private int column;

        public Coordinate(int currentRow, int currentColumn)
            : this()
        {
            this.Row = currentRow;
            this.Column = currentColumn;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                this.column = value;
            }
        }
    }
}

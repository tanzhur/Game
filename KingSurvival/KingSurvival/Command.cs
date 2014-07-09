namespace KingSurvival
{
    using Enums;
    using Interfaces;

    public class Command : ICommand
    {
        private char targetID;
        private Moves move;

        public Command(char targetID, Moves move)
        {
            this.TargetID = targetID;
            this.Move = move;
        }

        public char TargetID
        {
            get
            {
                return this.targetID;
            }

            private set
            {
                Validator.CheckCharIsNotLetter(value, "Target ID");
                this.targetID = value;
            }
        }

        public Moves Move
        {
            get
            {
                return this.move;
            }

            private set
            {
                Validator.CheckValueIsNull(value, "Move coordinates");
                this.move = value;
            }
        }
    }
}

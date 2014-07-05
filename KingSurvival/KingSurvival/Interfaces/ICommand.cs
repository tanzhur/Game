namespace KingSurvivalGame.Interfaces
{
    using KingSurvivalGame.Enums;

    public interface ICommand
    {
        char TargetID { get; }

        Moves Move { get; }
    }
}

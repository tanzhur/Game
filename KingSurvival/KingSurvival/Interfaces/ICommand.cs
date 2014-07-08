namespace KingSurvival.Interfaces
{
    using Enums;

    public interface ICommand
    {
        char TargetID { get; }

        Moves Move { get; }
    }
}

namespace KingSurvival.Interfaces
{
    using Enums;

    /// <summary>
    /// Target ID and Move pair that represents a single command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the the Piece that should execute the command.
        /// </summary>
        char TargetID { get; }

        /// <summary>
        /// Gets the the current move command that the piece should execute.
        /// </summary>
        Moves Move { get; }
    }
}

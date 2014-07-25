namespace KingSurvival.Interfaces
{
    /// <summary>
    /// ICommand generator via user inputs or reactions.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Gets a single ICommand from the user input or reaction.
        /// </summary>
        /// <returns>ICommand holding the target ID and the move to be executed.</returns>
        /// <seealso cref="ICommand"/>
        ICommand GetCommand();

        /// <summary>
        /// Waits until the user enters something via the input or reacts.
        /// </summary>
        void PressAnyKey();
    }
}

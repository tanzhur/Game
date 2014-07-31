namespace KingSurvival.Game.Interfaces
{
    using KingSurvival.Game.Enums;

    /// <summary>
    /// Game object that can move via passed coordinates
    /// </summary>
    public interface IMovableGamePiece
    {
        /// <summary>
        /// Receives a Move to show if it is among the current allowed ones for the IPiece.
        /// </summary>
        /// <param name="move">Current Move that is going to be checked.</param>
        /// <returns>Answer whether the passed move is among the possible ones.</returns>
        bool IsValidMove(Moves move);

        /// <summary>
        /// Returns the future coordinates of the IPiece if it was to execute a current move.
        /// </summary>
        /// <param name="move">Current Move via which the future position of the IPiece is going to be calculated.</param>
        /// <returns>X-Y pair representing a point of the 2D space to be occupied by the IPiece.</returns>
        ICoordinates GetNewCoordinates(Moves move);

        /// <summary>
        /// Executes a move command by changing the current coordinates of the IPiece to the passed ones.
        /// </summary>
        /// <param name="newCoordinates">The new coordinates that the IPiece is going to occupy.</param>
        void Move(ICoordinates newCoordinates);
    }
}

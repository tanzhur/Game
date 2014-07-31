namespace KingSurvival.Game.Interfaces
{
    /// <summary>
    /// Represents an element that is able to be processed by the video renderer.
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Gets the 2D array of char elements representing the image of the object.
        /// </summary>
        char[,] Image { get; }
    }
}
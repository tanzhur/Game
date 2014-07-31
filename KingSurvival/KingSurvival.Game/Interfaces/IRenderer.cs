namespace KingSurvival.Game.Interfaces
{
    /// <summary>
    /// Represents a renderer able to process IRenderable objects.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Processes an IRenderable object by showing it in relation to the passed X-Y pair ICoordinates.
        /// </summary>
        /// <param name="target">IRenderable object to be processed.</param>
        /// <param name="leftTop">X-Y pair in relation to which to process the IRenderable object.</param>
        void Render(IRenderable target, ICoordinates leftTop);

        /// <summary>
        /// Processes text represented by string by showing it in relation to the passed X-Y pair ICoordinates.
        /// </summary>
        /// <param name="text">Text as a string to be processed.</param>
        /// <param name="leftTop">X-Y pair in relation to which to process the IRenderable object.</param>
        void RenderText(string text, ICoordinates leftTop);

        /// <summary>
        /// Clear all processed objects and text leaving a blank screen.
        /// </summary>
        void ClearScreen();
    }
}

namespace KingSurvivalGame.Interfaces
{
    public interface IGameBoard : IGamePieceObserver, IRenderable
    {
        int Width { get; }
        int Height { get; }

        int PlayfieldSize { get; }
    }
}

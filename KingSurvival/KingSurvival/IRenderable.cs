namespace KingSurvival
{
    public interface IRenderable
    {
        Coordinate GetTopLeft();

        char[,] GetImage();
    }
}

namespace KingSurvival
{
    public interface IMovable
    {
        Coordinate coords;
        // az promenih metodite doly za da se kompilira - preimenuvah i metoda move - trqbva da vrushta buleva stoinost. // dzhenko
        bool TryMove(Moves move);
    }
}

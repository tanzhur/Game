namespace KingSurvival.Interfaces
{
    public interface IController
    {
        ICommand GetCommand();

        void PressAnyKey();
    }
}

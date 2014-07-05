namespace KingSurvivalGame.Interfaces
{
    public interface IController
    {
        ICommand GetCommand();

        void PressAnyKey();
    }
}

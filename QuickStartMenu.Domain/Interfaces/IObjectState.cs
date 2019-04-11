namespace QuickStartMenu.Domain.Interfaces
{
    public interface IObjectState
    {
        bool HasChanged();
        void Update();
    }
}

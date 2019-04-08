using System.Windows.Media;

namespace QuickStartMenu.Domain.Interfaces
{
    public interface IQuickStartEntry
    {
        ImageSource Icon { get; }
        string Name { get; }
        string Path { get; }
        void Execute();
    }
}

using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Extensions;
using System.Diagnostics;
using System.Windows.Media;

namespace QuickStartMenu.Infrastructure.Windows
{
    public class ProgramQuickStartEntry : IQuickStartEntry
    {
        public ImageSource Icon { get; }

        public string Name { get; }

        public string Path { get; }

        public ProgramQuickStartEntry(ImageSource icon, string name, string path)
        {
            Icon = icon;
            Name = name;
            Path = path;
        }

        public void Execute() 
            => Process.Start(Path);

        public static ProgramQuickStartEntry FromPath(string path, string name) 
            => new ProgramQuickStartEntry(System.Drawing.Icon.ExtractAssociatedIcon(path).ToImageSource(), name, path);
    }
}

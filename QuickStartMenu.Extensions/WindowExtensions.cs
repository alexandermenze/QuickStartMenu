using System.Windows;

namespace QuickStartMenu.Extensions
{
    public static class WindowExtensions
    {
        public static void BringToTop(this Window window)
        {
            if (!window.IsVisible)
                window.Show();

            if (window.WindowState == WindowState.Minimized)
                window.WindowState = WindowState.Normal;

            window.Activate();
            window.Topmost = true;
            window.Topmost = false;
            window.Focus();
        }
    }
}

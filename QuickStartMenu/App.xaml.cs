using System.Windows;

namespace QuickStartMenu
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            new MenuWindow().Show();
        }
    }
}

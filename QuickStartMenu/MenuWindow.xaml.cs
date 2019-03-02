using System;
using System.Windows;

namespace QuickStartMenu
{
    /// <summary>
    /// Interaktionslogik für MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            Deactivated += OnDeactivated;
        }

        private void OnDeactivated(object sender, EventArgs e) 
            => Hide();

        private void MenuWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }
    }
}

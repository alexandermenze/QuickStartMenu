using System;
using System.Windows;

namespace QuickStartMenu
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            Deactivated += OnDeactivated;
            Activated += OnActivated;

            SetStartupPosition();
        }

        private void OnActivated(object sender, EventArgs e) 
            => TxtSearchBar.Focus();

        private void OnDeactivated(object sender, EventArgs e) 
            => Hide();

        private void SetStartupPosition()
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }
    }
}

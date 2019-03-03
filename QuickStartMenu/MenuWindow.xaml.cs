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

            SetStartupPosition();
        }

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

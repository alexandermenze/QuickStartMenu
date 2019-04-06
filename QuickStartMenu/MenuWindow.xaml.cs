using QuickStartMenu.Controls.QuickStartEntry;
using QuickStartMenu.Extensions;
using System;
using System.Collections.Generic;
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

            DataContext = new List<QuickStartEntryModel>
            {
                new QuickStartEntryModel
                {
                    Icon = System.Drawing.Icon.ExtractAssociatedIcon(
                        @"C:\Program Files (x86)\Google\Chrome Beta\Application\chrome.exe").ToImageSource(),
                    Name = "Chrome",
                    Path = @"C:\Program Files (x86)\Google\Chrome Beta\Application\chrome.exe"
                }
            };
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

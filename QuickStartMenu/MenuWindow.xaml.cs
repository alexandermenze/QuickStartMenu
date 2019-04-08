using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Infrastructure.Windows;
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

            DataContext = new List<IQuickStartEntry>
            {
                ProgramQuickStartEntry.FromPath(@"C:\Program Files (x86)\Google\Chrome Beta\Application\chrome.exe", "Chrome"),
                ProgramQuickStartEntry.FromPath(@"C:\Program Files (x86)\WinSCP\WinSCP.exe", "WinSCP"),
                ProgramQuickStartEntry.FromPath(@"C:\Program Files\GIMP 2\bin\gimp-2.10.exe", "GIMP"),
                ProgramQuickStartEntry.FromPath(@"C:\Users\menze\Desktop\OneNote.lnk", "OneNote")
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

        private void DataGrid_OnMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) 
            => ((IQuickStartEntry)DataGrid.SelectedValue).Execute();
    }
}

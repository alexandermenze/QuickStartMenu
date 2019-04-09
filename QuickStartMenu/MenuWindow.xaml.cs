using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Infrastructure.Windows;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

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

        private void DataGrid_OnMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) 
            => ((IQuickStartEntry)DataGrid.SelectedValue).Execute();

        private void TxtSearchBar_OnKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                
            }
        }

        private void CollectionViewSource_OnFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is IQuickStartEntry quickStartEntry))
                return;

            e.Accepted = quickStartEntry.Name.Contains(TxtSearchBar.Text);
        }
    }
}

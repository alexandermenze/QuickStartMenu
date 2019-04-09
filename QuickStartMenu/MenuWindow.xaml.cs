using QuickStartMenu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace QuickStartMenu
{
    public partial class MenuWindow : Window
    {
        private readonly ICollectionView _collectionView;

        public MenuWindow(IEnumerable<IQuickStartEntry> quickStartEntries)
        {
            InitializeComponent();
            Deactivated += OnDeactivated;
            Activated += OnActivated;

            SetStartupPosition();

            _collectionView = CollectionViewSource.GetDefaultView(quickStartEntries);
            _collectionView.Filter = DataGrid_OnFilter;
            DataGrid.ItemsSource = _collectionView;
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
            => _collectionView.Refresh();

        private bool DataGrid_OnFilter(object obj)
        {
            if (!(obj is IQuickStartEntry quickStartEntry))
                return false;

            return quickStartEntry.Name.Contains(TxtSearchBar.Text);
        }
    }
}

using QuickStartMenu.BL.Comparer;
using QuickStartMenu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QuickStartMenu
{
    public partial class MenuWindow : Window
    {
        private readonly IListView<IQuickStartEntry> _listView;

        public MenuWindow(IEnumerable<IQuickStartEntry> quickStartEntries)
        {
            _listView =
                new BusinessLogic.DataStructures.ListView<IQuickStartEntry>(quickStartEntries.ToList())
                {
                    SortFunction = new DamerauLevenshteinSorter { CompareValueGetter = () => TxtSearchBar.Text }
                };

            InitializeComponent();
            Deactivated += OnDeactivated;
            Activated += OnActivated;

            SetStartupPosition();

            DataGrid.ItemsSource = _listView;
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
            _listView.Refresh();
            DataGrid.
        }
    }
}

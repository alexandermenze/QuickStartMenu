using QuickStartMenu.BL.Comparer;
using QuickStartMenu.BL.DataStructures;
using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace QuickStartMenu
{
    public partial class MenuWindow : Window
    {
        public IListView<IQuickStartEntry> ListView { get; }

        public MenuWindow(IEnumerable<IQuickStartEntry> quickStartEntries)
        {
            ListView =
                new ListView<IQuickStartEntry>(quickStartEntries.ToList())
                {
                    SortFunction = new QuickStartEntrySorter {CompareValueGetter = () => TxtSearchBar.Text}
                };

            InitializeComponent();
            Deactivated += OnDeactivated;
            Activated += OnActivated;

            SetStartupPosition();

            DataGrid.ItemsSource = ListView;
        }

        private void OnActivated(object sender, EventArgs e)
            => TxtSearchBar.Focus();

        private void OnDeactivated(object sender, EventArgs e)
        {
            TxtSearchBar.Clear();
            Hide();
        }

        private void SetStartupPosition()
        {
            var desktopWorkingArea = SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
        }

        private void DataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
            => StartSelected();

        private void DataGrid_OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            e.Handled = true;
            StartSelected();
        }

        private void TxtSearchBar_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Down)
            {
                Keyboard.Focus(DataGrid.SelectedCells.First().GetCell());
                return;
            }

            ListView.Refresh();
            DataGrid.SelectedIndex = 0;
        }

        private void StartSelected()
            => ((IQuickStartEntry)DataGrid.SelectedValue).Execute();
    }
}

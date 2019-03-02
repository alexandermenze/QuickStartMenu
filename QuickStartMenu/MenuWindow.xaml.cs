using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Domain.ValueTypes;
using QuickStartMenu.Infrastructure.Windows;
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
    }
}

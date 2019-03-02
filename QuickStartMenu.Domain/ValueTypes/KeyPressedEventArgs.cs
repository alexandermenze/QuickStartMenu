using System;
using System.Windows.Input;

namespace QuickStartMenu.Domain.ValueTypes
{
    public class KeyPressedEventArgs : EventArgs
    {
        public Key Key { get; set; }
        public ModifierKeys ModifierKeys { get; set; }
    }
}

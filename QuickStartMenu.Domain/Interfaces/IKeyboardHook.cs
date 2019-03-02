using QuickStartMenu.Domain.ValueTypes;
using System;
using System.Windows.Input;

namespace QuickStartMenu.Domain.Interfaces
{
    public interface IKeyboardHook : IDisposable
    {
        event EventHandler<KeyPressedEventArgs> KeyPressed;
        void RegisterKey(Key key, ModifierKeys modifiers);
    }
}

using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Domain.ValueTypes;
using QuickStartMenu.Extensions;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuickStartMenu.Infrastructure.Windows
{
    public class WindowsKeyboardHook : IKeyboardHook
    {
        private class KeyMessageWindow : NativeWindow, IDisposable
        {
            private const int WmHotkey = 0x0312;

            public event EventHandler<KeyPressedEventArgs> KeyPressed; 

            public void StartMessageReceiving() 
                => CreateHandle(new CreateParams());

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg != WmHotkey)
                    return;

                var winFormsKey = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                var modifiers = (ModifierKeys)((int)m.LParam & 0xFFFF);

                KeyPressed?.Invoke(this,
                    new KeyPressedEventArgs {Key = winFormsKey.ToWpfKey(), ModifierKeys = modifiers});
            }


            public void Dispose() 
                => DestroyHandle();
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly KeyMessageWindow _keyMessageWindow;
        private int _hotkeyId = 0;

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public WindowsKeyboardHook()
        {
            _keyMessageWindow = new KeyMessageWindow();
            _keyMessageWindow.StartMessageReceiving();
            _keyMessageWindow.KeyPressed += KeyMessageWindow_OnKeyPressed;
        }

        public void RegisterKey(Key key, ModifierKeys modifiers)
        {
            _hotkeyId++;

            if (!RegisterHotKey(_keyMessageWindow.Handle, _hotkeyId, (uint) modifiers, (uint) key.ToWinFormsKey()))
                throw new InvalidOperationException("Could not register key binding!");
        }

        public void Dispose()
        {
            for (var i = _hotkeyId; i > 0; i--)
                UnregisterHotKey(_keyMessageWindow.Handle, i);

            _keyMessageWindow.Dispose();
        }

        private void KeyMessageWindow_OnKeyPressed(object sender, KeyPressedEventArgs e) 
            => KeyPressed?.Invoke(this, e);
    }
}

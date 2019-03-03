using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Domain.ValueTypes;
using QuickStartMenu.Extensions;
using QuickStartMenu.Infrastructure.Windows;
using System.Windows;

namespace QuickStartMenu
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private readonly Settings.Settings _settings;
        private readonly IKeyboardHook _keyboardHook;
        private readonly MenuWindow _menuWindow;

        public App()
        {
            _settings = new Settings.Settings(QuickStartMenu.Properties.Settings.Default);
            _keyboardHook = new WindowsKeyboardHook();
            _menuWindow = new MenuWindow();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            RegisterHotKeys();
        }

        private void RegisterHotKeys()
        {
            _keyboardHook.RegisterKey(_settings.GetHotkey(), _settings.GetModifierKeys());
            _keyboardHook.KeyPressed += KeyboardHook_OnKeyPressed;
        }

        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedEventArgs e) 
            => _menuWindow.BringToTop();
    }
}
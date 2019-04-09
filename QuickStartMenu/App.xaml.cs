using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Domain.ValueTypes;
using QuickStartMenu.Extensions;
using QuickStartMenu.Infrastructure.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;

namespace QuickStartMenu
{
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
            _menuWindow.DataContext = GetShortcuts();
            RegisterHotKeys();
        }

        private IList<IQuickStartEntry> GetShortcuts()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var shortcutsFolder = Path.Combine(appDataPath, nameof(QuickStartMenu), "Shortcuts");
            EnsureFolderExists(shortcutsFolder);

            var quickStartEntries = new List<IQuickStartEntry>();

            return new DirectoryInfo(shortcutsFolder)
                .EnumerateFiles()
                .Select(file => 
                    new ProgramQuickStartEntry(
                        Icon.ExtractAssociatedIcon(file.FullName).ToImageSource(), 
                        file.Name.Substring(0, file.Name.Length - file.Extension.Length), 
                        file.FullName))
                .ToList<IQuickStartEntry>();
        }

        private void EnsureFolderExists(string path) 
            => Directory.CreateDirectory(path);

        private void RegisterHotKeys()
        {
            _keyboardHook.RegisterKey(_settings.GetHotkey(), _settings.GetModifierKeys());
            _keyboardHook.KeyPressed += KeyboardHook_OnKeyPressed;
        }

        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedEventArgs e) 
            => _menuWindow.BringToTop();
    }
}
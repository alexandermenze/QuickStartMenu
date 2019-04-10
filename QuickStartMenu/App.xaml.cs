using QuickStartMenu.BL.Comparer;
using QuickStartMenu.BusinessLogic.DataStructures;
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
        private IKeyboardHook _keyboardHook;
        private MenuWindow _menuWindow;

        public App()
        {
            _settings = new Settings.Settings(QuickStartMenu.Properties.Settings.Default);
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            _keyboardHook = new WindowsKeyboardHook();
            _menuWindow = new MenuWindow(GetShortcuts());
            RegisterHotKeys();
        }

        private IList<IQuickStartEntry> GetShortcuts()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var shortcutsFolder = Path.Combine(appDataPath, nameof(QuickStartMenu), "Shortcuts");
            EnsureFolderExists(shortcutsFolder);

            return new DirectoryInfo(shortcutsFolder)
                .EnumerateFiles()
                .Select(file => 
                    new ProgramQuickStartEntry(
                        Icon.ExtractAssociatedIcon(file.FullName).ToImageSource(), 
                        file.GetFileNameWithoutExtension(), 
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
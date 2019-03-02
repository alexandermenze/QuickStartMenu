using System;
using System.Windows.Input;

namespace QuickStartMenu.Settings
{
    internal class Settings
    {
        private readonly Properties.Settings _appSettings;

        public Settings(Properties.Settings appSettings)
        {
            _appSettings = appSettings;
        }

        public Key GetHotkey() 
            => (Key) Enum.Parse(typeof(Key), _appSettings.Hotkey);

        public ModifierKeys GetModifierKeys()
        {
            var modifierKeys = ModifierKeys.None;

            foreach (var modifierString in _appSettings.Modifiers)
            {
                var modifier = (ModifierKeys) Enum.Parse(typeof(ModifierKeys), modifierString);
                modifierKeys = modifierKeys | modifier;
            }

            return modifierKeys;
        }
    }
}

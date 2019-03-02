using System.Windows.Forms;
using System.Windows.Input;

namespace QuickStartMenu.Extensions
{
    public static class KeysExtensions
    {
        public static Key ToWpfKey(this Keys key) 
            => KeyInterop.KeyFromVirtualKey((int) key);

        public static Keys ToWinFormsKey(this Key key) 
            => (Keys) KeyInterop.VirtualKeyFromKey(key);
    }
}

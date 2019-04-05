using System.Drawing;
using System.Windows.Controls;
using QuickStartMenu.Extensions;

namespace QuickStartMenu.Controls.QuickStartEntry
{
    public partial class QuickStartEntry : UserControl
    {
        public QuickStartEntry()
        {
            DataContext = new QuickStartEntryModel
            {
                Icon = Icon.ExtractAssociatedIcon(@"C:\Program Files (x86)\Google\Chrome Beta\Application\chrome.exe").ToImageSource(),
                Name = "Chrome",
                Path = @"C:\Program Files (x86)\Google\Chrome Beta\Application\chrome.exe"
            };

            InitializeComponent();
        }
    }
}

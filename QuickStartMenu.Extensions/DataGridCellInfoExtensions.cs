using System.Windows.Controls;

namespace QuickStartMenu.Extensions
{
    public static class DataGridCellInfoExtensions
    {
        public static DataGridCell GetCell(this DataGridCellInfo cellInfo)
        {
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            return (DataGridCell) cellContent?.Parent;
        }
    }
}

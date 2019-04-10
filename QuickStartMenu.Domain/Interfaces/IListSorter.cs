using System.Collections.Generic;

namespace QuickStartMenu.Domain.Interfaces
{
    public interface IListSorter<T>
    {
        IList<T> Sort(IList<T> list);
    }
}

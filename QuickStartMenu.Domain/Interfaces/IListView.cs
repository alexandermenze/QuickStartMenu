using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace QuickStartMenu.Domain.Interfaces
{
    public interface IListView<T> : INotifyCollectionChanged, INotifyPropertyChanged, IEnumerable<T>, IEnumerable
    {
        IList<T> Items { get; }
        IListSorter<T> SortFunction { get; set; }
        void Update(IList<T> values);
        void Refresh();
    }
}

using QuickStartMenu.Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace QuickStartMenu.BL.DataStructures
{
    public class ListView<T> : IListView<T>
    {
        private IList<T> _items;

        public IList<T> Items => GetItemsSorted();
        public IListSorter<T> SortFunction { get; set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public ListView(IList<T> values)
        {
            _items = values;
        }

        public void Update(IList<T> values)
        {
            _items = values;
            Refresh();
        }

        public void Refresh()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            CollectionChanged?.Invoke(this, 
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public IEnumerator<T> GetEnumerator() 
            => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();

        private IList<T> GetItemsSorted() 
            => SortFunction?.Sort(_items.ToList()) ?? _items.ToList();
    }
}

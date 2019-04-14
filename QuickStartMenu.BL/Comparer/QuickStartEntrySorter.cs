using QuickStartMenu.BL.Algorithms;
using QuickStartMenu.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace QuickStartMenu.BL.Comparer
{
    public class QuickStartEntrySorter : IListSorter<IQuickStartEntry>
    {
        public System.Func<string> CompareValueGetter { get; set; }

        private string CompareValue => CompareValueGetter();

        public IList<IQuickStartEntry> Sort(IList<IQuickStartEntry> list)
        {
            return list.OrderBy(entry => StringDifference.CompareWordsIgnoreCase(CompareValue, entry.Name)).ToList();
        }
    }
}

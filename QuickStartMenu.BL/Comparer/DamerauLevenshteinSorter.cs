using QuickStartMenu.BusinessLogic.Algorithms;
using QuickStartMenu.Domain.Interfaces;
using QuickStartMenu.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace QuickStartMenu.BL.Comparer
{
    public class DamerauLevenshteinSorter : IListSorter<IQuickStartEntry>
    {
        public System.Func<string> CompareValueGetter { get; set; }

        private string CompareValue => CompareValueGetter();

        public IList<IQuickStartEntry> Sort(IList<IQuickStartEntry> list)
        {
            return list.OrderBy(entry =>
            {
                var bonus = 0;

                if (entry.Name.StartsWithIgnoreCase(CompareValue))
                    bonus += -20;
                else if (entry.Name.ContainsIgnoreCase(CompareValue))
                    bonus += -10;

                return entry.Name.DistanceToIgnoreCase(CompareValue) + bonus;
            }).ToList();
        }
    }
}

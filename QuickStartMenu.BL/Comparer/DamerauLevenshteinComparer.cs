using QuickStartMenu.BusinessLogic.Algorithms;
using System.Collections;

namespace QuickStartMenu.BusinessLogic.Comparer
{
    public class DamerauLevenshteinComparer : IComparer
    {
        private readonly string _compareTo;

        public DamerauLevenshteinComparer(string compareTo)
        {
            _compareTo = compareTo;
        }

        public int Compare(object x, object y)
        {
            if (!(x is string stringA) || !(y is string stringB))
                return 0;

            var aDistance = stringA.DistanceToIgnoreCase(_compareTo);
            var bDistance = stringB.DistanceToIgnoreCase(_compareTo);

            var diff = bDistance - aDistance;

            return diff < 0 ? -1
                : diff > 0 ? 1
                : 0;
        }
    }
}

using System;
using System.Linq;

namespace QuickStartMenu.BL.Algorithms
{
    public static class StringDifference
    {
        public static int CompareIgnoreCase(string a, string b) 
            => Compare(a.ToLowerInvariant(), b.ToLowerInvariant());

        public static int CompareWordsIgnoreCase(string a, string b) 
            => CompareMin(a.ToLowerInvariant(), b.ToLowerInvariant());

        public static int CompareMin(string source, string compareTo)
        {
            var words = compareTo.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return words
                .Select(w => Compare(source, w))
                .Min();
        }

        public static int Compare(string source, string compareTo)
        {
            var diff = 0;

            if (compareTo.Length <= source.Length)
                return int.MaxValue - 1;

            if (source.Length == 0)
                return int.MaxValue;

            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] != compareTo[i]) diff += 10;

                if (i < source.Length - 1)
                {
                    if (source[i] != compareTo[i + 1]) diff += 5;
                }

                if (i >= 1)
                {
                    if (source[i] != compareTo[i + 1]) diff += 5;
                }
            }

            return diff;
        }
    }
}

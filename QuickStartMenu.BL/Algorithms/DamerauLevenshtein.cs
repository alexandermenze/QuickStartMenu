using System;
using static System.String;

namespace QuickStartMenu.BL.Algorithms
{
    public static class DamerauLevenshtein
    {
        public static int DamerauLevenshteinDistanceTo(this string s, string targetString) 
            => DamerauLevenshteinDistance(s, targetString);

        public static int DistanceToIgnoreCase(this string s, string targetString) 
            => DamerauLevenshteinDistance(s.ToLowerInvariant(), targetString.ToLowerInvariant());

        private static int DamerauLevenshteinDistance(string string1, string string2)
        {
            if (IsNullOrEmpty(string1))
                return !IsNullOrEmpty(string2) ? string2.Length : 0;

            if (IsNullOrEmpty(string2))
                return !IsNullOrEmpty(string1) ? string1.Length : 0;

            var length1 = string1.Length;
            var length2 = string2.Length;

            var d = new int[length1 + 1, length2 + 1];

            for (var i = 0; i <= d.GetUpperBound(0); i++)
                d[i, 0] = i;

            for (var i = 0; i <= d.GetUpperBound(1); i++)
                d[0, i] = i;

            for (var i = 1; i <= d.GetUpperBound(0); i++)
            {
                for (var j = 1; j <= d.GetUpperBound(1); j++)
                {
                    var cost = string1[i - 1] == string2[j - 1] ? 0 : 1;

                    var del = d[i - 1, j] + 1;
                    var ins = d[i, j - 1] + 1;
                    var sub = d[i - 1, j - 1] + cost;

                    d[i, j] = Math.Min(del, Math.Min(ins, sub));

                    if (i > 1 && j > 1 && string1[i - 1] == string2[j - 2] && string1[i - 2] == string2[j - 1])
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }
    }
}

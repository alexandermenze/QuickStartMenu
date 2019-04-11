namespace QuickStartMenu.BL.Algorithms
{
    public static class StringDifference
    {
        public static int CompareIgnoreCase(string a, string b) 
            => Compare(a.ToLowerInvariant(), b.ToLowerInvariant());

        public static int Compare(string a, string b)
        {
            var diff = 0;
            var minLength = a.Length < b.Length ? a.Length : b.Length;

            for (var i = 0; i < minLength; i++)
            {
                if (a[i] != b[i])
                {
                    diff++;
                }
            }

            return diff;
        }
    }
}

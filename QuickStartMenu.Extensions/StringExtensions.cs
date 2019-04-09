namespace QuickStartMenu.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string a, string b) 
            => a.ToLowerInvariant().Contains(b.ToLowerInvariant());
    }
}

public static class StringExtensions
{
    public static bool ConsistsOfUniqueElements(this string s)
        => s.ToHashSet().Count == s.Length;
}
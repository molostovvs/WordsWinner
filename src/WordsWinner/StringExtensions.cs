namespace WordsWinner;

public static class StringExtensions
{
    /// <summary>
    ///     Checks whether the string consists of unique characters
    /// </summary>
    /// <param name="s">The string being checked</param>
    /// <returns>True if input string consists only of unique elements</returns>
    public static bool ConsistsOfUniqueElements(this string s)
        => s.ToHashSet().Count == s.Length;
}
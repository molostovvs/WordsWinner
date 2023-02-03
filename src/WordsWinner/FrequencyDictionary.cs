using System.Collections.Immutable;
using System.Diagnostics;

namespace WordsWinner;

public static class FrequencyDictionary
{
    private const string DictionaryName = "freqrnc2011.csv";

    /// <summary>
    ///     Sorted list of words and their frequency
    /// </summary>
    public static readonly List<(string Word, float Frequency)> FrequentWords;

    private static readonly Dictionary<char, int> FrequentLetters;

    static FrequencyDictionary()
    {
        var pathToDictionary = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", DictionaryName);
        var nounsWithFrequency = File.ReadAllLines(pathToDictionary)
                                     .Select(s => s.Split())
                                     .Where(s => s[1] == "s" && s[0].Length == 5);

        FrequentWords = nounsWithFrequency.Select(arr => (arr[0], float.Parse(arr[2]))).OrderBy(t => -t.Item2).ToList();

        FrequentLetters = nounsWithFrequency.SelectMany(arr => arr[0])
                                            .GroupBy(c => c)
                                            .OrderBy(gr => -gr.Count())
                                            .ToDictionary(gr => gr.Key, gr => gr.Count());
    }
}
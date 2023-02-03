namespace WordsWinner;

public static class Guesser
{
    /// <summary>
    ///     Guesses the first word
    /// </summary>
    /// <returns>Guessed word</returns>
    public static string GuessFirstWord()
        => GuessWordWithMostFrequentLetters();

    /// <summary>
    ///     Based on the given word, guesses the next word
    /// </summary>
    /// <param name="word">A word on the basis of which the next word is guessed</param>
    /// <param name="allowDuplicateLetters">A parameter that indicates whether a guessed word can contain duplicate letters</param>
    /// <returns>Guessed word</returns>
    public static string GuessNextWord(Word word, bool allowDuplicateLetters = true)
    {
        //filter wrong letters
        var words = FrequencyDictionary.FrequentWords.Where(t => t.Word.All(ch => !word.WrongLetters.Contains(ch)));

        //filter correct and inappropriate letters
        for (var i = 0; i < word.Letters.Length; i++)
        {
            var temp = i;
            if (word.InappropriateLetters[temp] is not null)
                words = words.Where(t => !word.InappropriateLetters[temp].Contains(t.Word[temp]));

            if (word.Letters[i] != default)
                words = words.Where(t => word.Letters[temp] == t.Word[temp]);
        }

        foreach (var ch in word.InappropriateLetters.SelectMany(hs => hs ?? Enumerable.Empty<char>()))
            words = words.Where(t => t.Word.Contains(ch));

        return words.First().Word;
    }

    private static string GuessWordWithMostFrequentLetters()
    {
        //TODO: сделать реальный выбор на основании частотности букв
        var rnd = new Random().Next(50);
        return FrequencyDictionary.FrequentWords.Where(t => t.Word.ConsistsOfUniqueElements()).Skip(rnd).First().Word;
    }
}
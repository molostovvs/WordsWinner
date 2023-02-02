namespace application;

public static class Guesser
{
    public static string GuessFirstWord()
        => GuessWordWithMostFrequentLetters();

    public static string GuessNextWord(Word word, bool allowDuplicateLetters = true)
    {
        //filter wrong letters
        var words = FrequencyDictionary.FrequentWords.Where(t => t.Word.All(ch => word.WrongLetters.Contains(ch)));

        //filter correct and inappropriate letters
        for (var i = 0; i < word.Letters.Length; i++)
        {
            var temp = i;
            words = words.Where(
                t => word.InappropriateLetters[temp] != null && word.InappropriateLetters[temp].Contains(t.Word[temp])
            );

            if (word.Letters[i] != default)
                words = words.Where(t => word.Letters[temp] == t.Word[temp]);
        }

        foreach (var ch in word.InappropriateLetters.SelectMany(hs => hs))
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
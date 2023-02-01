namespace application;

public static class Guesser
{
    public static string GuessFirstWord()
    {
        return GuessWordWithMostFrequentLetters();
    }

    public static string GuessNextWord(Word word)
    {
        //filter wrong letters
        var words = FrequencyDictionary.FrequentWords.Where(t => t.Word.All(ch => !word.WrongLetters.Contains(ch)));
        //filter inappropriate letters and correct
        for (var i = 0; i < word.Letters.Length; i++)
        {
            var temp = i;
            words = words.Where(t => !word.InappropriateLetters[temp].Contains(t.Word[temp]));

            if (word.Letters[i] != default)
                words = words.Where(t => word.Letters[temp] == t.Word[temp]);
        }

        return words.First().Word;
    }

    private static string GuessWordWithMostFrequentLetters()
    {
        //TODO: сделать реальный выбор на основании частотности букв
        var rnd = new Random().Next(50);
        return FrequencyDictionary.FrequentWords[rnd].Word;
    }
}
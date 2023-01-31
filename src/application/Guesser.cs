namespace application;

public class Guesser
{
    private int _round;

    public Guesser()
    {
        _round = 0;
    }

    public string GuessFirstWord()
    {
        if (_round == 0)
            return GuessNextWord(null);
        throw new InvalidOperationException($"You cant guess first word on round N {_round}");
    }

    public string GuessNextWord(Word word)
    {
        if (_round == 0)
        {
            _round++;
            return GuessWordWithMostFrequentLetters();
        }

        _round++;
        return GuessWord(word);
    }

    private string GuessWord(Word word)
    {
        throw new NotImplementedException();
    }

    private string GuessWordWithMostFrequentLetters()
    {
        //TODO: сделать реальный выбор на основании частотности букв
        var rnd = new Random().Next(50);
        return FrequencyDictionary.FrequentWords[rnd].Word;
    }
}
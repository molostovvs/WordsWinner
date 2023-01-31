namespace application;

public class Guesser
{
    private readonly Word _word;
    private int _round;

    public Guesser()
    {
        _word = new Word(5);
        _round = 0;
    }

    public string GuessNextWord()
    {
        if (_round == 0)
        {
            _round++;
            return GuessWordWithMostFrequentLetters();
        }

        _round++;
        return GuessWord();
    }

    private string GuessWord()
    {
        throw new NotImplementedException();
    }

    private string GuessWordWithMostFrequentLetters()
    {
        //TODO: сделать реальный выбор на основании частотности букв
        var rnd = new Random().Next(50);
        return FrequencyDictionary.FrequentWords[rnd].Word;
    }

    public void ParseCorrectLetters(string letters)
    {
        throw new NotImplementedException();
    }

    public void ParseWrongLetters(string letters)
    {
        var parsedLetters = letters.Where(char.IsLetter).Select(ch => new Letter(ch));
        _word.AddWrongLetters(parsedLetters);
    }

    public void ParseInappropriateLetters(string letters)
    {
        var parsedLetters = letters.Where(char.IsLetter).Select(ch => new Letter(ch));
        _word.AddInappropriateLetters(parsedLetters);
    }
}
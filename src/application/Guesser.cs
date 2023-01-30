namespace application;

public class Guesser
{
    private readonly Word _word;
    private readonly int _round;

    public Guesser()
    {
        _word = new Word(5);
        _round = 0;
    }

    public string GuessNextWord()
    {
        if (_round == 0)
            return GuessWordWithMostFrequentLetters();
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
        throw new NotImplementedException();
    }

    public void ParseInappropriateLetters(string letters)
    {
        throw new NotImplementedException();
    }
}
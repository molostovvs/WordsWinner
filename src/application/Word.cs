namespace application;

public class Word
{
    public readonly char[] Letters;
    public readonly HashSet<char> WrongLetters; //этих букв нет в слове
    public readonly HashSet<char>[] InappropriateLetters;

    public Word(int length = 5)
    {
        Letters = new char[5];
        WrongLetters = new HashSet<char>();
        InappropriateLetters = new HashSet<char>[length];
        for (var i = 0; i < length; i++)
            InappropriateLetters[i] = new HashSet<char>();
    }

    public void AddCorrectLetters(string letters)
    {
        for (var i = 0; i < letters.Length; i++)
        {
            var ch = letters[i];
            if (!char.IsLetter(ch))
                continue;

            if (WrongLetters.Contains(ch))
                throw new InvalidOperationException();

            if (InappropriateLetters[i].Contains(ch))
                throw new InvalidOperationException();

            if (Letters[i] != default)
                throw new InvalidOperationException();

            Letters[i] = ch;
        }
    }

    public void AddWrongLetters(string letters)
    {
        foreach (var letter in letters)
        {
            if (InappropriateLetters.Any(hs => hs.Contains(letter)) || Letters.Contains(letter))
                throw new InvalidOperationException();
            if (char.IsLetter(letter))
                WrongLetters.Add(letter);
        }
    }

    public void AddInappropriateLetters(string letters)
    {
        for (var i = 0; i < letters.Length; i++)
        {
            var ch = letters[i];
            if (!char.IsLetter(ch))
                continue;

            if (WrongLetters.Contains(ch))
                throw new InvalidOperationException();

            InappropriateLetters[i].Add(ch);
        }
    }

    /*private IEnumerable<Letter> ParseLetters(string letters)
        => letters.Where(char.IsLetter).Select(ch => new Letter(ch));

    private bool IsCurentLetterIsInappropriate(Letter letter)
    {
        var inappropriateLetter = InappropriateLetters.FirstOrDefault(l => l.Char == letter.Char);
        if (inappropriateLetter is null)
            return false;
        return inappropriateLetter.AbsentOn.Contains(letter.PresentOn.First());
    }*/
}
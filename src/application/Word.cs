namespace application;

public class Word
{
    public readonly char[] Letters;
    public readonly HashSet<char> WrongLetters; //этих букв нет в слове
    public readonly HashSet<char>?[] InappropriateLetters;

    public Word(int length = 5)
    {
        Letters = new char[5];
        WrongLetters = new HashSet<char>();
        InappropriateLetters = new HashSet<char>[length];
    }

    public void AddCorrectLetters(string? letters)
    {
        if (letters is null)
            return;
        for (var i = 0; i < letters.Length; i++)
        {
            var ch = letters[i];
            if (!char.IsLetter(ch))
                continue;

            if (WrongLetters.Contains(ch))
                throw new InvalidOperationException();

            if (InappropriateLetters[i] != null && InappropriateLetters[i].Contains(ch))
                throw new InvalidOperationException();

            if (Letters[i] != default && Letters[i] != ch)
                throw new InvalidOperationException();

            Letters[i] = ch;
        }
    }

    public void AddWrongLetters(string? letters)
    {
        if (letters is null)
            return;
        foreach (var letter in letters)
        {
            if (InappropriateLetters.Any(hs => hs != null && hs.Contains(letter)) || Letters.Contains(letter))
                throw new InvalidOperationException();
            if (char.IsLetter(letter))
                WrongLetters.Add(letter);
        }
    }

    public void AddInappropriateLetters(string? letters)
    {
        if (letters is null)
            return;
        for (var i = 0; i < letters.Length; i++)
        {
            var ch = letters[i];
            if (!char.IsLetter(ch))
                continue;

            if (WrongLetters.Contains(ch))
                throw new InvalidOperationException();

            InappropriateLetters[i] ??= new HashSet<char>();
            InappropriateLetters[i]?.Add(ch);
        }
    }
}
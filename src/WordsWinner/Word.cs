namespace WordsWinner;

public class Word
{
    public readonly char[] Letters;
    public readonly HashSet<char> WrongLetters;
    public readonly HashSet<char>?[] InappropriateLetters;

    /// <summary>
    ///     Initializes a new instance of the Word class
    /// </summary>
    /// <param name="length">length of the word</param>
    public Word(int length = 5)
    {
        Letters = new char[5];
        WrongLetters = new HashSet<char>();
        InappropriateLetters = new HashSet<char>[length];
    }

    /// <summary>
    ///     Adds letters in certain positions in word as inappropriate for these positions
    /// </summary>
    /// <param name="letters">Letters in certain positions that should be considered correct</param>
    /// <exception cref="InvalidOperationException">
    ///     One ore more of letters already considered as correct or inappropriate, or
    ///     trying to add new correct letter when correct letter for this position already set
    /// </exception>
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

    /// <summary>
    ///     Adds letters as wrong letters for the word
    /// </summary>
    /// <param name="letters">Letters that should be considered wrong</param>
    /// <exception cref="InvalidOperationException">One ore more of letters already considered as correct or inappropriate</exception>
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

    /// <summary>
    ///     Adds letters in certain positions in word as inappropriate for these positions
    /// </summary>
    /// <param name="letters">Letters in certain positions that should be considered inappropriate</param>
    /// <exception cref="InvalidOperationException">One or more of letters considered as wrong letter</exception>
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
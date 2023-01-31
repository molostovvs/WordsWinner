namespace application;

public class Word
{
    public readonly Letter[] Letters;
    public readonly HashSet<Letter> WrongLetters; //этих букв нет в слове
    public readonly HashSet<Letter> InappropriateLetters; // эти буквы есть в слове, но не на тех позициях

    public Word(int length)
    {
        Letters = new Letter[length];
        WrongLetters = new HashSet<Letter>();
        InappropriateLetters = new HashSet<Letter>();
    }

    public void AddCorrectLetters(string letters)
    {
        for (var i = 0; i < letters.Length; i++)
        {
            var ch = letters[i];
            if (char.IsLetter(ch))
                if (Letters[i] is null)
                    Letters[i] = new Letter(ch, new[] { i });
        }
    }

    public void AddWrongLetters(string letters)
    {
        foreach (var letter in ParseLetters(letters))
        {
            if (InappropriateLetters.Contains(letter))
                throw new InvalidOperationException();
            WrongLetters.Add(letter);
        }
    }

    public void AddInappropriateLetters(string letters)
    {
        foreach (var letter in ParseLetters(letters))
        {
            if (WrongLetters.Contains(letter))
                throw new InvalidOperationException();
            InappropriateLetters.Add(letter);
        }
    }

    private IEnumerable<Letter> ParseLetters(string letters)
        => letters.Where(char.IsLetter).Select(ch => new Letter(ch));
}
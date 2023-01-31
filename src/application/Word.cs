namespace application;

public class Word
{
    private readonly Letter[] _letters;
    private readonly HashSet<Letter> _wrongLetters; //этих букв нет в слове
    private readonly HashSet<Letter> _inppropriateLetters; // эти буквы есть в слове, но не на тех позициях

    public Word(int length)
        => _letters = new Letter[length];

    public void AddCorrectLetters(string letters)
    {
        for (var i = 0; i < letters.Length; i++)
        {
            var ch = letters[i];
            if (char.IsLetter(ch))
                if (_letters[i] is null)
                    _letters[i] = new Letter(ch, new[] { i });
        }
    }

    public void AddWrongLetters(string letters)
    {
        foreach (var letter in ParseLetters(letters))
            _wrongLetters.Add(letter);
    }

    public void AddInappropriateLetters(string letters)
    {
        foreach (var letter in ParseLetters(letters))
            _inppropriateLetters.Add(letter);
    }

    private IEnumerable<Letter> ParseLetters(string letters)
        => letters.Where(char.IsLetter).Select(ch => new Letter(ch));
}
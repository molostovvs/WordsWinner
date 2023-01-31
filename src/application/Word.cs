namespace application;

public class Word
{
    private readonly Letter[] _letters;
    private readonly HashSet<Letter> _wrongLetters; //этих букв нет в слове
    private readonly HashSet<Letter> _inppropriateLetters; // эти буквы есть в слове, но не на тех позициях

    public Word(int length)
        => _letters = new Letter[length];

    public void AddWrongLetters(IEnumerable<Letter> letters)
    {
        foreach (var letter in letters)
            _wrongLetters.Add(letter);
    }

    public void AddInappropriateLetters(IEnumerable<Letter> letters)
    {
        foreach (var letter in letters)
            _inppropriateLetters.Add(letter);
    }
}
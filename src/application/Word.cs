namespace application;

public class Word
{
    private readonly Letter[] _letters;
    private readonly HashSet<Letter> _incorrectLetters; //этих букв нет в слове
    private readonly HashSet<Letter> _correctLetters; // эти буквы есть в слове, но не на тех позициях

    public Word(int length)
        => _letters = new Letter[length];
}
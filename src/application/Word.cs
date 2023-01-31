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
            if (!char.IsLetter(ch))
                continue;

            Letter letter;
            if (!Letters.Where(l => l != null).Select(l => l.Char).Contains(ch))
            {
                letter = new Letter(ch, new[] { i });
            }
            else
            {
                letter = Letters.Where(l => l != null).First(l => l.Char == ch);
                letter.PresentOn.Add(i);
            }

            if (WrongLetters.Contains(letter))
                throw new InvalidOperationException();

            if (IsCurentLetterIsInappropriate(letter))
                throw new InvalidOperationException();

            if (Letters[i] is null)
                Letters[i] = new Letter(ch, new[] { i });
        }
    }

    public void AddWrongLetters(string letters)
    {
        foreach (var letter in ParseLetters(letters))
        {
            if (InappropriateLetters.Contains(letter) || Letters.Contains(letter))
                throw new InvalidOperationException();
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

            var letter = new Letter(ch, null, new[] { i });

            if (WrongLetters.Contains(letter))
                throw new InvalidOperationException();

            InappropriateLetters.Add(letter);
        }
    }

    private IEnumerable<Letter> ParseLetters(string letters)
        => letters.Where(char.IsLetter).Select(ch => new Letter(ch));
    
    private bool IsCurentLetterIsInappropriate(Letter letter)
    {
        var inappropriateLetter = InappropriateLetters.FirstOrDefault(l => l.Char == letter.Char);
        if (inappropriateLetter is null)
            return false;
        return inappropriateLetter.AbsentOn.Contains(letter.PresentOn.First());
    }
}
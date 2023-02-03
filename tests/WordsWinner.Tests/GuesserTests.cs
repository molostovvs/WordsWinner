using WordsWinner;

namespace application.unit_tests;

public class GuesserTests
{
    [Test]
    public void GuessFirstWordCorrectly()
    {
        var result = Guesser.GuessFirstWord();
        result.Should().NotBeEmpty("First guess shold return word");
        Console.WriteLine(result);
    }

    [TestCase("к   н", " о а", "рмч")]
    public void GuessTest(string correct, string inappropriate, string wrong)
    {
        var word = new Word();
        word.AddCorrectLetters(correct);
        word.AddInappropriateLetters(inappropriate);
        word.AddWrongLetters(wrong);
        Guesser.GuessNextWord(word);
    }

    [TestCase("ок")]
    [TestCase("сл   ")]
    [TestCase("д о")]
    public void GuessShouldUseInappropriateLetters(string inputInappropriateLetters)
    {
        var word = new Word();
        word.AddInappropriateLetters(inputInappropriateLetters);

        var guessedWords = new List<string>();
        for (var i = 0; i < 100; i++)
            guessedWords.Add(Guesser.GuessNextWord(word));

        var inappropriateLetters = word.InappropriateLetters.SelectMany(hs => hs ?? Enumerable.Empty<char>());

        foreach (var guessedWord in guessedWords)
        {
            foreach (var inappropriateLetter in inappropriateLetters)
                guessedWord.Should().Contain(inappropriateLetter.ToString());
        }
    }

    [TestCase("ок")]
    [TestCase("сл   ")]
    [TestCase("вр")]
    [TestCase("а")]
    [TestCase("аоке")]
    public void GuessShouldntUseWrongLetters(string wrongLetters)
    {
        var word = new Word();
        word.AddWrongLetters(wrongLetters);

        var guessedWords = new List<string>();
        for (var i = 0; i < 200; i++)
            guessedWords.Add(Guesser.GuessNextWord(word));

        foreach (var guessedWord in guessedWords)
        {
            foreach (var wrongLetter in word.WrongLetters)
                guessedWord.Should().NotContain(wrongLetter.ToString());
        }
    }

    [Test]
    public void GuessFirstWordShouldReturnWordWithoutRepetitiveLetters()
    {
        var guessedWords = new List<string>();
        for (var i = 0; i < 100; i++)
            guessedWords.Add(Guesser.GuessFirstWord());

        foreach (var word in guessedWords)
            word.ToCharArray().Should().OnlyHaveUniqueItems();
    }
}
using FluentAssertions;

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

    [Test]
    public void GuessTest()
    {
        var word = new Word();
        word.AddWrongLetters("аоедк");
        word.AddInappropriateLetters("    ь");
        word.AddCorrectLetters(" и   ");
        Guesser.GuessFirstWord();
        Guesser.GuessNextWord(word);
    }

    [TestCase("а о р")]
    [TestCase("ок")]
    [TestCase("  л у")]
    [TestCase("д о")]
    public void GuessShouldUseInappropriateLetters(string inputInappropriateLetters)
    {
        var word = new Word();
        word.AddInappropriateLetters(inputInappropriateLetters);

        var guessedWords = new List<string>();
        for (var i = 0; i < 100; i++)
            guessedWords.Add(Guesser.GuessNextWord(word));

        var inappropriateLetters = word.InappropriateLetters.SelectMany(hs => hs);

        foreach (var guessedWord in guessedWords)
        {
            foreach (var inappropriateLetter in inappropriateLetters)
                guessedWord.Should().Contain(inappropriateLetter.ToString());
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
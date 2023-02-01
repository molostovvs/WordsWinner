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
}
using FluentAssertions;

namespace application.unit_tests;

public class GuesserTests
{
    private Guesser guesser;

    [SetUp]
    public void Setup()
    {
        guesser = new Guesser();
    }

    [Test]
    public void GuessFirstWordCorrectly()
    {
        var result = guesser.GuessFirstWord();
        result.Should().NotBeEmpty("First guess shold return word");
        Console.WriteLine(result);
    }

    [Test]
    public void GuessFirstWordTwiceFails()
    {
        guesser.GuessFirstWord();
        var secondGuess = () => guesser.GuessFirstWord();
        secondGuess.Should().Throw<InvalidOperationException>().WithMessage("You cant guess first word on round N 1");
    }
}
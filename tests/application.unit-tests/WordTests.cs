using FluentAssertions;

namespace application.unit_tests;

public class WordTests
{
    private Word _word = null!;

    [SetUp]
    public void Setup()
        => _word = new Word();

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    [TestCase("     ")]
    [TestCase("")]
    public void AddWrongLetters(string input)
    {
        _word.AddWrongLetters(input);
        var expected = input.Where(char.IsLetter).ToHashSet();
        _word.WrongLetters.Should()?.BeEquivalentTo(expected);
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddWrongLettersWhenTheyAreCorrect(string input)
    {
        _word.AddCorrectLetters(input);
        var addingWrongLetters = () => _word.AddWrongLetters(input);
        addingWrongLetters.Should()?.Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    [TestCase("     ")]
    [TestCase("с")]
    [TestCase(" л")]
    [TestCase("  о")]
    [TestCase("   в")]
    [TestCase("    о")]
    [TestCase("")]
    public void AddInappropriateLetters(string input)
    {
        _word.AddInappropriateLetters(input);
        var expected = ParseInappropriateString(input);
        _word.InappropriateLetters.Should()?.BeEquivalentTo(expected);
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddWrongLettersWhenTheyAreInappropriate(string input)
    {
        _word.AddInappropriateLetters(input);
        var addingWrongLetters = () => _word.AddWrongLetters(input);
        addingWrongLetters.Should()?.Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddInappropriateLettersWhenTheyAreWrong(string input)
    {
        _word.AddWrongLetters(input);
        var addingInappropriateLetters = () => _word.AddInappropriateLetters(input);
        addingInappropriateLetters.Should()?.Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    [TestCase("     ")]
    [TestCase("с")]
    [TestCase(" л")]
    [TestCase("  о")]
    [TestCase("   в")]
    [TestCase("    о")]
    [TestCase("")]
    public void AddCorrectLetters(string input)
    {
        _word.AddCorrectLetters(input);
        var expected = ParseStringToCharArray(input);
        _word.Letters.Should()?.BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddCorrectLettersWhenTheyAreWrong(string input)
    {
        _word.AddWrongLetters(input);
        var addingCorrectLetters = () => _word.AddCorrectLetters(input);
        addingCorrectLetters.Should()?.Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddCorrectLettersWhenTheyAreInappropriate(string input)
    {
        _word.AddInappropriateLetters(input);
        var addingCorrectLetters = () => _word.AddCorrectLetters(input);
        addingCorrectLetters.Should()?.Throw<InvalidOperationException>();
    }

    [TestCase("a    ", "    a")]
    [TestCase(" a   ", "    a")]
    [TestCase("  a  ", "    a")]
    [TestCase("   a ", "    a")]
    [TestCase("    a", "a    ")]
    [TestCase("a    ", " aaaa")]
    public void AddCorrectLettersWhenTheyAreInappropriateOnAnotherPosition(string inappropriate, string correct)
    {
        _word.AddInappropriateLetters(inappropriate);
        var addingCorrectLetters = () => _word.AddCorrectLetters(correct);
        addingCorrectLetters.Should()?.NotThrow();
    }

    private char[] ParseStringToCharArray(string input)
    {
        var res = new char[5];
        for (var i = 0; i < input.Length; i++)
            if (char.IsLetter(input[i]))
                res[i] = input[i];

        return res;
    }

    private HashSet<char>[] ParseInappropriateString(string input)
    {
        var res = new HashSet<char>[5];

        for (int i = 0; i < input.Length; i++)
            if (char.IsLetter(input[i]))
                res[i] = new HashSet<char>(new[] { input[i] });

        return res;
    }
}
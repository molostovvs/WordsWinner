using FluentAssertions;

namespace application.unit_tests;

public class WordTests
{
    private Word word;

    [SetUp]
    public void Setup()
    {
        word = new Word(5);
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddWrongLetters(string input)
    {
        word.AddWrongLetters(input);
        var letters = ParseStringToLetters(input);
        word.WrongLetters.Should().BeEquivalentTo(letters.ToHashSet());
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddWrongLettersWhenTheyAreCorrect(string input)
    {
        word.AddCorrectLetters(input);
        var addingWrongLetters = () => word.AddWrongLetters(input);
        addingWrongLetters.Should().Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddInappropriateLetters(string input)
    {
        word.AddInappropriateLetters(input);
        var letters = ParseStringToLetters(input);
        word.InappropriateLetters.Should().BeEquivalentTo(letters.ToHashSet());
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddWrongLettersWhenTheyAreInappropriate(string input)
    {
        word.AddInappropriateLetters(input);
        var addingWrongLetters = () => word.AddWrongLetters(input);
        addingWrongLetters.Should().Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddInappropriateLettersWhenTheyAreWrong(string input)
    {
        word.AddWrongLetters(input);
        var addingInappropriateLetters = () => word.AddInappropriateLetters(input);
        addingInappropriateLetters.Should().Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddCorrectLetters(string input)
    {
        word.AddCorrectLetters(input);
        var letters = ParseStringToLettersWithPositions(input);
        word.Letters.Should().BeEquivalentTo(letters, opt => opt.WithStrictOrdering());
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddCorrectLettersWhenTheyAreWrong(string input)
    {
        word.AddWrongLetters(input);
        var addingCorrectLetters = () => word.AddCorrectLetters(input);
        addingCorrectLetters.Should().Throw<InvalidOperationException>();
    }

    [TestCase("слово")]
    [TestCase("с    ")]
    [TestCase(" л   ")]
    [TestCase("  о  ")]
    [TestCase("   в ")]
    [TestCase("    о")]
    public void AddCorrectLettersWhenTheyAreInappropriate(string input)
    {
        word.AddInappropriateLetters(input);
        var addingCorrectLetters = () => word.AddCorrectLetters(input);
        addingCorrectLetters.Should().Throw<InvalidOperationException>();
    }

    private Letter[] ParseStringToLettersWithPositions(string input)
    {
        var res = new Letter[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            var ch = input[i];
            if (char.IsLetter(ch))
                res[i] = new Letter(ch, new[] { i });
        }

        return res;
    }

    private IEnumerable<Letter> ParseStringToLetters(string input)
    {
        foreach (var letter in input)
            if (char.IsLetter(letter))
                yield return new Letter(letter);
    }
}
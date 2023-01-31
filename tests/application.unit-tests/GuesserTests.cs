namespace application.unit_tests;

public class Tests
{
    private Guesser guesser;

    [SetUp]
    public void Setup()
    {
        guesser = new Guesser();
    }

    [TestCase("abcde")]
    public void ParseWrongLettersTest(string letters)
    {
        guesser.ParseWrongLetters(letters);
        guesser.
    }
}
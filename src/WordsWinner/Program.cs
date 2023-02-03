namespace WordsWinner;

public static class Program
{
    public static void Main(string[] args)
    {
        //TODO: Move logic to Game class
        //TODO: Allow modify word length and rounds count before start

        Console.Title = "Words Winner v0.1.0";
        Console.Clear();
        var word = new Word();

        for (var i = 0; i <= 5; i++)
        {
            if (i == 0)
                UI.ProvideUser("Предлагаю превое слово:", Guesser.GuessFirstWord());

            UI.AskForUserInput("Введите верно угаданные буквы", word.AddCorrectLetters);

            if (word.Letters.All(ch => ch != default)) //TODO: maybe move this to GameWon method fo Game.cs
            {
                Console.Clear();
                UI.Print("CONGRATS!");
                break;
            }

            UI.AskForUserInput("Введите буквы не на своих местах", word.AddInappropriateLetters);
            UI.AskForUserInput("Введите неверно угаданные буквы", word.AddWrongLetters);
            UI.ProvideUser("Предлагаю следующее слово", Guesser.GuessNextWord(word));
        }
    }
}
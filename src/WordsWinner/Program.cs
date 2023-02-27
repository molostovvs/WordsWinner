namespace WordsWinner;

public static class Program
{
    public static void Main(string[] args)
    {
        //TODO: Move logic to Game class
        //TODO: Allow modify word length and rounds count before start
        //TODO: Allow reguess word for example tinkoff doesnt know about "будни"
        //TODO: Allow guess word with 5 different letters on any turn, for example its impossible to guess "лесть" in 5 turns

        Console.Title = "Words Winner v0.1.0"; //TODO: take version from assembly
        Console.Clear();
        var word = new Word();
        UI.ProvideUser("Предлагаю первое слово:", Guesser.GuessFirstWord());

        for (var i = 0; i <= 5; i++)
        {
            UI.AskForUserInput("Введите верно угаданные буквы:", word.AddCorrectLetters, UI.StringFiller.Numbers);
            if (word.Letters.All(ch => ch != default)) //TODO: maybe move this to GameWon method of Game.cs
            {
                Console.Clear();
                UI.Print("CONGRATS!");
                break;
            }

            UI.AskForUserInput("Введите буквы не на своих местах:", word.AddInappropriateLetters, UI.StringFiller.Numbers);
            UI.AskForUserInput("Введите неверно угаданные буквы:", word.AddWrongLetters, UI.StringFiller.Underscore);
            UI.ProvideUser("Предлагаю следующее слово:", Guesser.GuessNextWord(word));
        }
    }
}
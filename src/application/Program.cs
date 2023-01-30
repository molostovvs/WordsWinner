using application;

public class Program
{
    public static void Main(string[] args)
    {
        /* ConsoleUI
        Console.WriteLine("Введите буквы");
        Console.WriteLine("_____");
        Console.SetCursorPosition(0, 1);
        var x = Console.ReadLine();
        Console.WriteLine(x);*/

        var dict = FrequencyDictionary.FrequentWords;
        var chars = FrequencyDictionary.FrequentLetters;
        var guesser = new Guesser();
        //TODO: Вынести писанину в UI? Или в метод Guessera с помощью TextWriter
        Console.WriteLine("Предлагаю следующее слово:");
        Console.WriteLine(guesser.GuessNextWord());

        /*//TODO: Вынести цикл в класс Game?
        for (var i = 1; i < 5; i++)
        {
            Console.WriteLine("Введите верно угаданные буквы");
            guesser.ParseCorrectLetters(Console.ReadLine());
            Console.WriteLine("Введите неверно угаданные буквы");
            guesser.ParseWrongLetters(Console.ReadLine());
            Console.WriteLine("Введите буквы не на своих местах");
            guesser.ParseInappropriateLetters(Console.ReadLine());
            Console.WriteLine("Предлагаю следующее слово:");
            Console.WriteLine(guesser.GuessNextWord());
        }*/
    }
}
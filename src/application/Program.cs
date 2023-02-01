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

        var word = new Word();
        var guesser = new Guesser();
        //TODO: Вынести писанину в UI? Или в метод Guessera с помощью TextWriter
        Console.WriteLine("Предлагаю следующее слово:");
        Console.WriteLine(guesser.GuessFirstWord());

        //TODO: Вынести цикл в класс Game?
        for (var i = 1; i < 5; i++)
        {
            Console.WriteLine("Введите верно угаданные буквы");
            word.AddCorrectLetters(Console.ReadLine());
            Console.WriteLine("Введите неверно угаданные буквы");
            word.AddWrongLetters(Console.ReadLine());
            Console.WriteLine("Введите буквы не на своих местах");
            word.AddInappropriateLetters(Console.ReadLine());
            Console.WriteLine("Предлагаю следующее слово:");
            Console.WriteLine(guesser.GuessNextWord(word));
        }
    }
}
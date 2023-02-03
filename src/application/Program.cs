using application;

public class Program
{
    public static void Main(string[] args)
    {
        //TODO: Move all writings to consolte to UI class
        //TODO: Move logic to Game class
        //TODO: Allow modify word length and rounds count before start
        var word = new Word();
        Console.WriteLine("Предлагаю следующее слово:");
        Console.WriteLine(Guesser.GuessFirstWord());

        for (var i = 1; i <= 5; i++)
        {
            Console.WriteLine("Введите верно угаданные буквы");
            word.AddCorrectLetters(Console.ReadLine());
            Console.WriteLine("Введите буквы не на своих местах");
            word.AddInappropriateLetters(Console.ReadLine());
            Console.WriteLine("Введите неверно угаданные буквы");
            word.AddWrongLetters(Console.ReadLine());
            Console.WriteLine("Предлагаю следующее слово:");
            Console.WriteLine(Guesser.GuessNextWord(word));
        }
    }
}
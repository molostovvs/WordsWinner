using System.Text;

namespace WordsWinner;

public static class UI
{
    public static void AskForUserInput(string prompt, Action<string?> action)
    {
        Print(prompt);
        ReadTo(action);
        ClearLastLines(2);
    }

    public static void ProvideUser(string description, string offer)
    {
        Print(description);
        Print(offer);
    }

    public static void Print(string @string)
        => Console.WriteLine(@string);

    private static void ClearLastLines(int numberOfLines)
    {
        var start = Console.CursorTop - numberOfLines;
        Console.SetCursorPosition(0, start);
        var sb = new StringBuilder();
        sb.Append(' ', Console.WindowWidth);
        for (var i = 0; i < numberOfLines; i++)
            Console.WriteLine(sb);
        Console.SetCursorPosition(0, start);
    }

    private static void ReadTo(Action<string?> addCorrectLetters)
        => addCorrectLetters.Invoke(Console.ReadLine());

    enum StringFiller
    {
        Underscore, Numbers, None,
    }
}
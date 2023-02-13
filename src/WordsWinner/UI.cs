using System.Text;

namespace WordsWinner;

public static class UI
{
    public static void AskForUserInput(string prompt, Action<string?> action, StringFiller filler = StringFiller.Blank)
    {
        Print(prompt);
        ReadTo(action, filler);
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

    private static void ReadTo(Action<string?> addLettersToCategory, StringFiller filler)
    {
        FillString(filler);
        addLettersToCategory.Invoke(Console.ReadLine());
    }

    private static void FillString(StringFiller stringFiller)
    {
        var defColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        if (stringFiller == StringFiller.Underscore)
            Console.Write(new string('_', 5));
        if (stringFiller == StringFiller.Numbers)
            for (var i = 1; i <= 5; i++)
                Console.Write(i);

        Console.SetCursorPosition(0, Console.CursorTop);
        Console.ForegroundColor = defColor;
    }

    public enum StringFiller
    {
        Underscore, Numbers, Blank,
    }
}
using System.Diagnostics;
using application;

public class Program
{
    public static void Main()
    {
        var sw = new Stopwatch();
        sw.Start();
        var x = System.IO.File.ReadAllLines(
            @"C:\Users\molos\source\projects\WordsWinner\src\application\resources\freqrnc2011.csv"
        ).Select(s => s.Split()).ToArray();
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Reset();
        sw.Start();
        var wordsWithLength5 = x.Where(s => s[1] == "s" && s[0].Length == 5).Select(s => (s[0], s[2])).OrderByDescending(t => t.Item2).ToArray();
        var y = wordsWithLength5[0];
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
}
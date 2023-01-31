namespace application;

public struct Letter
{
    public char Char;
    public HashSet<int> PresentOn { get; set; }
    public HashSet<int> AbsentOn { get; set; }

    public Letter(char c)
        => Char = c;
}
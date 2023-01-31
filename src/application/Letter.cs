namespace application;

public class Letter
{
    public char Char;
    public HashSet<int> PresentOn { get; set; }
    public HashSet<int> AbsentOn { get; set; }

    public Letter(char c, IEnumerable<int> presentOn = null, IEnumerable<int> absentOn = null)
    {
        Char = c;
        PresentOn = presentOn.ToHashSet();
        AbsentOn = absentOn.ToHashSet();
    }
}
namespace application;

public struct Letter
{
    public readonly char Lettter;
    public HashSet<int> PresentOn { get; set; }
    public HashSet<int> AbsentOn { get; set; }
}
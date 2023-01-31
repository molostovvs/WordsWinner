namespace application;

public class Letter
{
    public char Char;
    public HashSet<int>? PresentOn { get; set; }
    public HashSet<int>? AbsentOn { get; set; }

    public Letter(char c, IEnumerable<int>? presentOn = null, IEnumerable<int>? absentOn = null)
    {
        Char = c;
        PresentOn = new HashSet<int>(presentOn ?? Enumerable.Empty<int>());
        AbsentOn = new HashSet<int>(absentOn ?? Enumerable.Empty<int>());
    }

    public override int GetHashCode()
        => Char.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        var otherLetter = obj as Letter;
        if (otherLetter is null)
            return false;
        return GetHashCode() == otherLetter.GetHashCode();
    }
}
namespace application;

public struct Letter
{
    private IEnumerable<int> _presentPositions;
    private IEnumerable<int> _absentOnThisPositions;

    public char Lettter;
    public IEnumerable<int> PresentOn => _presentPositions;
    public IEnumerable<int> AbsentOn => _absentOnThisPositions;
}
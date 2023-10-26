namespace Core.Domain;
internal class RangeBuilder
{
    private IQuestion _question;
    private readonly int _min;
    private readonly List<Range> _ranges = new();
    internal RangeBuilder(Range range, int min, IQuestion question)
    {
        _ranges.Add(range);
        _min = min;
        _question = question;
    }
    public RangeBuilder UpTo(int max)
    {
        _ranges.Add(new Range(_question, _min, max));
        return this;
    }
    public RangeBuilder Question(IQuestion question)
    {
        _question = question;
        return this;
    }
    internal List<Range> Otherwise(IQuestion question)
    {
        _ranges.Add(new Range(question, _min, int.MaxValue));
        return _ranges;
    }
}
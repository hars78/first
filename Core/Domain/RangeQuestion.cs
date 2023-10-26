namespace Core.Domain;
internal class RangeQuestion : IQuestion
{
    private readonly string _question;
    private readonly List<Range> _ranges;
    private int? _reply;
    internal RangeQuestion(string question, List<Range> ranges)
    {
        _question = question;
        _ranges = ranges;
    }

    public string Print()
    {
        return _question;
    }
    public IQuestion NextQuestion() => _reply == null ? this : Range.NextQuestion(_ranges, _reply);
    public IQuestion Answer(string reply)
    {
         _reply = int.Parse(reply);
         return NextQuestion();
    }
}
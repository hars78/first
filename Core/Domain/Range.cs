namespace Core.Domain;
internal class Range
{
    private readonly IQuestion _question;
    private readonly int _minimumValue;
    private readonly int _maximumValue;
    internal Range(IQuestion question, int minimumValue, int maximumValue)
    {
        _question = question;
        _minimumValue = minimumValue;
        _maximumValue = maximumValue;
    }
    public static IQuestion NextQuestion(List<Range> ranges, int? reply) =>
        ranges.First(range => IsInRange(range, reply))._question;
    private static bool IsInRange(Range range, int? reply) =>
        range._minimumValue <= reply && range._maximumValue >= reply;
}
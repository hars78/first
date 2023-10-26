namespace Core.Domain;
internal class MultipleChoiceQuestion : IQuestion
{
    private readonly string _question;
    private readonly IQuestion _defaultAnswer;
    private readonly List<Option> _options;
    private string? _reply;
    public MultipleChoiceQuestion(string question, IQuestion defaultAnswer, List<Option> options)
    {
        _question = question;
        _defaultAnswer = defaultAnswer;
        _options = options;
    }
    public string Print()
    {
        return _question;
    }
    public IQuestion NextQuestion() => _reply == null ? this : Option.NextQuestion(_options, _reply, _defaultAnswer);
    public IQuestion Answer(string reply)
    {
         _reply = reply.ToLower();
         return NextQuestion();
    }
}
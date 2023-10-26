namespace Core.Domain;

internal class BooleanQuestion : IQuestion
{
    private readonly string _question;
    private readonly IQuestion _trueAnswer;
    private readonly IQuestion _falseAnswer;
    private bool? _reply;
    public BooleanQuestion(string question, IQuestion trueAnswer, IQuestion falseAnswer)
    {
        _question = question;
        _trueAnswer = trueAnswer;
        _falseAnswer = falseAnswer;
    }

    public IQuestion Answer(string reply)
    {
        _reply = bool.Parse(reply);
        return NextQuestion();
    }

    public string Print()
    {
        return _question;
    }

    public IQuestion NextQuestion() => _reply == null ? this : (bool)_reply ? _trueAnswer : _falseAnswer;
}
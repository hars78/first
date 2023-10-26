namespace Core.Domain;

internal class NumericQuestion : IQuestion
{
    private readonly string _question;
    private readonly IQuestion _answer;
    private int? _reply;
    public NumericQuestion(string question,IQuestion answer)
    {
        _question = question;
        _answer = answer;
    }

    public string Print()
    {
        return _question;
    }
    public IQuestion NextQuestion() => _reply == null ? this : _answer;
    public IQuestion Answer(string reply)
    {
         _reply = int.Parse(reply);
         return NextQuestion();
    }
}
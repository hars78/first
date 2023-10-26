namespace Core.Domain;

internal class TerminalQuestion : IQuestion
{
    private readonly string _answer;

    internal TerminalQuestion(string answer)
    {
        _answer = answer;
    }
    public string Print()
    {
        return _answer;
    }
    public IQuestion Answer(string reply) => throw new InvalidOperationException("No More Questions, You are done");
    public IQuestion NextQuestion() => this;
}
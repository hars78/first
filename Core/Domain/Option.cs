namespace Core.Domain;
internal class Option
{
    private readonly IQuestion _question;
    private readonly string _option;
    public Option(IQuestion question, string option)
    {
        _question = question;
        _option = option.ToLower();
    }
    public static IQuestion NextQuestion(IEnumerable<Option> options, string reply, IQuestion defaultAnswer) =>
        options.FirstOrDefault(option => option._option == reply)?._question ?? defaultAnswer;
}
using static Core.Domain.TerminalQuestion;

namespace Core.Domain;
public interface IQuestion
{
    public static IQuestion Success() => new TerminalQuestion("Success");
    public static IQuestion Failure() => new TerminalQuestion("Failure");
    public static IQuestion FoodQuestion() => "How do you Rate Pasta on a scale of 10".Range(Success().UpTo(0).Question(Success()).UpTo(3).Question(Success()).UpTo(7).Question(Failure()).UpTo(10).Otherwise(Failure()));
    public static IQuestion ColorQuestion() => "What is your Favorite Color?".MultiQuestion(Failure(),"white".Question(FoodQuestion()),"red".Question(Failure()));
    public static IQuestion AgeQuestion() => "What is your age?".Numeric(ColorQuestion());
    public static IQuestion NameQuestion() => "Are you Human??".Boolean(AgeQuestion(), Success());
    public string Print();
    public IQuestion NextQuestion();
    public IQuestion Answer(string reply);
}
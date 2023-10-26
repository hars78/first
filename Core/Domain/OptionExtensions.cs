namespace Core.Domain;
internal static class OptionExtensions
{ 
    internal static Option Question(this string option, IQuestion question) => new(question, option);
}
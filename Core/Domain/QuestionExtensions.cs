using Core.BusinessServices;

namespace Core.Domain;
internal static class QuestionExtensions
{
    internal static BooleanQuestion Boolean(this string option, IQuestion trueQuestion, IQuestion falseQuestion) =>
        new(option, trueQuestion, falseQuestion);
    internal static MultipleChoiceQuestion MultiQuestion(this string option, IQuestion defaultAnswer, params Option[] options) => new(option, defaultAnswer, options.ToList());
    internal static NumericQuestion Numeric(this string option, IQuestion question) => new(option, question);
    internal static RangeQuestion Range(this string option, List<Range> ranges) => new(option, ranges);
    internal static RangeBuilder UpTo(this IQuestion question, int max) => new(new Range(question, int.MinValue, max), max,question);
}
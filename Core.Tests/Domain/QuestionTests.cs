using Core.Dtos;
using static Core.Domain.IQuestion;
namespace Core.Tests.Domain;

public class QuestionTests
{
    [Fact]
    public void GetQuestionText()
    {
        NameQuestion().Print().Should().Be("Are you Human??");
        AgeQuestion().Print().Should().Be("What is your age?");
        ColorQuestion().Print().Should().Be("What is your Favorite Color?");
        FoodQuestion().Print().Should().Be("How do you Rate Pasta on a scale of 10");
        Success().Print().Should().Be("Success");
        Failure().Print().Should().Be("Failure");
    }

    [Fact]
    public void CheckNextQuestion()
    {
        NameQuestion().Print().Should().Be("Are you Human??");
        NameQuestion().Answer("true").Print().Should().Be("What is your age?");
        AgeQuestion().Answer("289").Print().Should().Be("What is your Favorite Color?");
        ColorQuestion().Answer("white").Print().Should().Be("How do you Rate Pasta on a scale of 10");
        FoodQuestion().Answer("4").Print().Should().Be("Success");
    }

    [Fact]
    public void CheckInvalidOperationException()
    {
        Success().Invoking(s=>s.Answer("answering terminal")).Should().Throw<InvalidOperationException>();
        Failure().Invoking(s => s.Answer("answering terminal")).Should().Throw<InvalidOperationException>();
    }
    [Fact]
    public void CheckFormatException()
    {
        NameQuestion().Print().Should().Be("Are you Human??");
        NameQuestion().Invoking(s => s.Answer("not a boolean")).Should().Throw<FormatException>();
        NameQuestion().Answer("true").Print().Should().Be("What is your age?");
        NameQuestion().Invoking(s => s.Answer("not a numeric")).Should().Throw<FormatException>();
        AgeQuestion().Answer("76").Print().Should().Be("What is your Favorite Color?");
        ColorQuestion().Answer("white").Print().Should().Be("How do you Rate Pasta on a scale of 10");
        FoodQuestion().Invoking(s => s.Answer("not a numeric")).Should().Throw<FormatException>();
        FoodQuestion().Answer("-1").Print().Should().Be("Success");
    }
}
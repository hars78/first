using Core.Dtos;
using Core.Mediators;

namespace Core.Tests.Mediators;

public class QuestionMediatorTests
{

    [Fact]
    public void CreateDto()
    {
        QuestionMediator.CreateDto(IQuestion.NameQuestion()).Should().Be(new QuestionDto("Are you Human??"));
        QuestionMediator.CreateDto(IQuestion.AgeQuestion()).Should().Be(new QuestionDto("What is your age?"));
        QuestionMediator.CreateDto(IQuestion.ColorQuestion()).Should().Be(new QuestionDto("What is your Favorite Color?"));
        QuestionMediator.CreateDto(IQuestion.FoodQuestion()).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
    }
}
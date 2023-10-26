using FluentAssertions;
using Infrastructure.Repositories;
using static Core.Domain.IQuestion;


namespace Infrastructure.Tests.Repositories;

public class QuestionRepositoryTests
{
    [Fact]
    public void GetCurrentQuestion()
    {
        var repository = InMemoryQuestionRepository.CreateWithInitialQuestion(1,NameQuestion());
        repository.GetCurrentQuestion(1).Print().Should().Be(NameQuestion().Print());

        repository = InMemoryQuestionRepository.CreateWithInitialQuestion(2,AgeQuestion());
        repository.GetCurrentQuestion(2).Print().Should().Be(AgeQuestion().Print());

        repository = InMemoryQuestionRepository.CreateWithInitialQuestion(3,ColorQuestion());
        repository.GetCurrentQuestion(3).Print().Should().Be(ColorQuestion().Print());

        repository = InMemoryQuestionRepository.CreateWithInitialQuestion(4,FoodQuestion());
        repository.GetCurrentQuestion(4).Print().Should().Be(FoodQuestion().Print());
    }

    [Fact]
    public void UpdateCurrentQuestion()
    {
        var repository = InMemoryQuestionRepository.CreateWithInitialQuestion(5,NameQuestion());
        repository.UpdateCurrentQuestion(1,AgeQuestion(),"Brian");
        repository.GetCurrentQuestion(1).Print().Should().Be(AgeQuestion().Print());
        repository.UpdateCurrentQuestion(1,ColorQuestion(),"22");
        repository.GetCurrentQuestion(1).Print().Should().Be(ColorQuestion().Print());
        repository.UpdateCurrentQuestion(1,FoodQuestion(),"white");
        repository.GetCurrentQuestion(1).Print().Should().Be(FoodQuestion().Print());
        repository.UpdateCurrentQuestion(1,Success(),"pasta");
        repository.GetCurrentQuestion(1).Print().Should().Be(Success().Print());
        repository.UpdateCurrentQuestion(1,Failure(),"answering terminal");
        repository.GetCurrentQuestion(1).Print().Should().Be(Failure().Print());
    }
}
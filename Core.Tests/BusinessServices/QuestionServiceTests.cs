using Core.BusinessServices;
using Core.Dtos;

namespace Core.Tests.BusinessServices;

public class QuestionServiceTests
{
    private readonly QuestionRepositoryFake _serviceMock;
    public QuestionServiceTests()
    {
        _serviceMock = new QuestionRepositoryFake(IQuestion.NameQuestion());
        _serviceMock.UpdateCurrentQuestion(1,IQuestion.NameQuestion(),"bhaskar");
    }
    [Fact]
    public void GetNextQuestion()
    {
        var service = new QuestionService(_serviceMock);
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Are you Human??"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Are you Human??"));
        service.SaveAnswer(1,"true");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your age?"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your age?"));
        service.SaveAnswer(1,"99");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.SaveAnswer(1,"white");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.SaveAnswer(1,"11");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Failure"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Failure"));
        Assert.Throws<InvalidOperationException>(() => service.SaveAnswer(1,"answering terminal IQuestion"));
    }
    
    [Fact]
    public void SaveAnswer()
    {
        var service = new QuestionService(_serviceMock);
        service.SaveAnswer(5,"true").Should().Be(new QuestionDto("What is your age?"));
        service.SaveAnswer(5,"53").Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.SaveAnswer(5,"Green").Should().Be(new QuestionDto("Failure"));
    }
    [Fact]
    public void ExceptionServiceTests()
    {
        var service = new QuestionService(_serviceMock);
        service.Invoking(s=>s.SaveAnswer(3," ")).Should().Throw<FormatException>();
        service.SaveAnswer(3,"true").Should().Be(new QuestionDto("What is your age?"));
        service.Invoking(s => s.SaveAnswer(3,"not a numeric")).Should().Throw<FormatException>();
        service.SaveAnswer(3,"54").Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.SaveAnswer(3,"wHItE").Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.Invoking(s => s.SaveAnswer(3,"not a numeric")).Should().Throw<FormatException>();
        service.SaveAnswer(3,"-3").Should().Be(new QuestionDto("Success"));
        service.Invoking(s => s.SaveAnswer(3,"answering terminal question")).Should().Throw<InvalidOperationException>();
    }
    [Fact]
    public void GetNextQuestionWithDifferentStudent()
    {
        var service = new QuestionService(_serviceMock);
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Are you Human??"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Are you Human??"));
        service.SaveAnswer(1, "true");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your age?"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your age?"));

        service.GetNextQuestion(2).Should().Be(new QuestionDto("Are you Human??"));
        service.GetNextQuestion(2).Should().Be(new QuestionDto("Are you Human??"));
        service.SaveAnswer(2, "true");
        service.GetNextQuestion(2).Should().Be(new QuestionDto("What is your age?"));
        service.GetNextQuestion(2).Should().Be(new QuestionDto("What is your age?"));
        service.SaveAnswer(2, "99");
        service.GetNextQuestion(2).Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.GetNextQuestion(2).Should().Be(new QuestionDto("What is your Favorite Color?"));

        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your age?"));
        service.SaveAnswer(1, "99");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.SaveAnswer(1, "white");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.SaveAnswer(1, "11");
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Failure"));
        service.GetNextQuestion(1).Should().Be(new QuestionDto("Failure"));
        Assert.Throws<InvalidOperationException>(() => service.SaveAnswer(1, "answering terminal IQuestion"));

        service.GetNextQuestion(2).Should().Be(new QuestionDto("What is your Favorite Color?"));
        service.SaveAnswer(2, "white");
        service.GetNextQuestion(2).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.GetNextQuestion(2).Should().Be(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        service.SaveAnswer(2, "11");
        service.GetNextQuestion(2).Should().Be(new QuestionDto("Failure"));
        service.GetNextQuestion(2).Should().Be(new QuestionDto("Failure"));
        Assert.Throws<InvalidOperationException>(() => service.SaveAnswer(2, "answering terminal IQuestion"));
    }
}
using Core.BusinessServices;
using Core.Domain;
using Core.Dtos;
using FluentAssertions;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace Api.Tests.IntegrationTests;
using Controllers;
using FluentAssertions.Primitives;

public class QuestionControllerTests
{
    private readonly QuestionsController _controller = new (
        new NullLogger<QuestionsController>(), 
        new QuestionService(InMemoryQuestionRepository.CreateWithInitialQuestion(1,IQuestion.NameQuestion())));

    
    [Fact]
    public void GetNextQuestion()
    {
        _controller.GetNextQuestion(1).Should().BeOkWithValue(new QuestionDto("Are you Human??"));
    }
    
    [Fact]
    public void SaveAnswer()
    {
        _controller.SaveAnswer(1,"true").Should().BeOkWithValue(new QuestionDto("What is your age?"));
        _controller.SaveAnswer(1,"55").Should().BeOkWithValue(new QuestionDto("What is your Favorite Color?"));
        _controller.SaveAnswer(1,"white").Should().BeOkWithValue(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        _controller.SaveAnswer(1,"1").Should().BeOkWithValue(new QuestionDto("Success"));
    }

    [Fact]
    public void InvalidOperationExceptionTests()
    {
        _controller.GetNextQuestion(2).Should().BeOkWithValue(new QuestionDto("Are you Human??"));
        _controller.SaveAnswer(2,"false");
        _controller.GetNextQuestion(2).Should().BeOkWithValue(new QuestionDto("Success"));
        _controller.SaveAnswer(2,"Answering terminal").Should().BadRequestWithValue("No More Questions, You are done");
    }
    [Fact]
    public void FormatExceptionTests()
    {
        _controller.GetNextQuestion(3).Should().BeOkWithValue(new QuestionDto("Are you Human??"));
        _controller.SaveAnswer(3,"not a boolean").Should().BadRequestWithValue("String 'not a boolean' was not recognized as a valid Boolean.");

        _controller.SaveAnswer(3,"true").Should().BeOkWithValue(new QuestionDto("What is your age?"));
        _controller.SaveAnswer(3,"not a numeric").Should().BadRequestWithValue("The input string 'not a numeric' was not in a correct format.");

        _controller.SaveAnswer(3,"65").Should().BeOkWithValue(new QuestionDto("What is your Favorite Color?"));

        _controller.SaveAnswer(3,"wHItE").Should().BeOkWithValue(new QuestionDto("How do you Rate Pasta on a scale of 10"));
        _controller.SaveAnswer(3,"not a numeric").Should().BadRequestWithValue("The input string 'not a numeric' was not in a correct format.");

        _controller.SaveAnswer(3,"-3").Should().BeOkWithValue(new QuestionDto("Success"));
    }
}

public static class TestExtensions
{
    public static void BeOkWithValue(this ObjectAssertions result, object value)
    {
        result.BeAssignableTo<OkObjectResult>().Subject.Value.Should().Be(value);
    }

    public static void BadRequestWithValue(this ObjectAssertions result, object value)
    {
        result.BeAssignableTo<BadRequestObjectResult>().Subject.Value.Should().Be(value);
    }
}

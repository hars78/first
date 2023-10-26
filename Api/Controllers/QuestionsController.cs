using Core.BusinessServices;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly QuestionService _questionService;
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(ILogger<QuestionsController> logger, QuestionService questionService)
    {
        _logger = logger;
        _questionService = questionService;
    }

    [HttpGet]
    public IActionResult GetNextQuestion(int studentId)
    {
        return Ok(_questionService.GetNextQuestion(studentId));
    }

    [HttpPost(Name = "SaveAnswer")]
    public IActionResult SaveAnswer(int studentId, [FromBody] string answer)
    {
        try
        {
            var nextQuestion = _questionService.SaveAnswer(studentId, answer);
            _logger.LogInformation("Next question: {IQuestion}", nextQuestion.Question);
            return Ok(nextQuestion);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("StudentId")]
    public IActionResult ListofAnswers(int studentId)
    {
        return Ok(_questionService.ListOfQuestionAnswers(studentId));
    }
}
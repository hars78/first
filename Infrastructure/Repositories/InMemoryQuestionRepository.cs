using Core.Domain;
using Core.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Repositories;

public class InMemoryQuestionRepository : IQuestionRepository
{
    private IQuestion _currentTextualQuestion;
    private static readonly Dictionary<int, Student> Students = new();
    private InMemoryQuestionRepository(IQuestion initialTextualQuestion)
    {
        _currentTextualQuestion = initialTextualQuestion;
    }

    public static InMemoryQuestionRepository CreateWithInitialQuestion(int studentId,IQuestion initialTextualQuestion)
    {
        Students.TryAdd(studentId, new Student(initialTextualQuestion));
        var student = Students[studentId];
        student.AnsweringQuestion=initialTextualQuestion;
        return new InMemoryQuestionRepository(initialTextualQuestion);
    }

    public IQuestion GetCurrentQuestion(int studentId)
    {
        Students.TryAdd(studentId, new Student(IQuestion.NameQuestion()));
        var student = Students[studentId];
        _currentTextualQuestion = student.AnsweringQuestion;
        return _currentTextualQuestion;
    }

    public IQuestion UpdateCurrentQuestion(int studentId, IQuestion textualQuestion, string answer)
    {
        Students.TryAdd(studentId, new Student(textualQuestion));
        var student = Students[studentId];
        student.StoreAnswers(_currentTextualQuestion.Print(), answer);
        student.AnsweringQuestion = textualQuestion;
        _currentTextualQuestion = student.AnsweringQuestion;
        return _currentTextualQuestion;
    }

    public string GetListOfAnswered(int studentId)
    {
        try
        {
            return JsonConvert.SerializeObject(Students[studentId].Answers);
        }
        catch (KeyNotFoundException)
        {
            return $"Student Id:{studentId} doesn't exist";
        }

    }
}
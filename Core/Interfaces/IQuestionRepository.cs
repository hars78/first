using Core.Domain;

namespace Core.Interfaces;

public interface IQuestionRepository
{
    IQuestion GetCurrentQuestion(int studentId);

    IQuestion UpdateCurrentQuestion(int studentId, IQuestion textualQuestion, string answer);
    string GetListOfAnswered(int studentId);
} 
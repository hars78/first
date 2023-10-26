using Core.Dtos;
using Core.Interfaces;
using Core.Mediators;

namespace Core.BusinessServices;


public class QuestionService
{
    private readonly IQuestionRepository _repository;

    public QuestionService(IQuestionRepository repository)
    {
        _repository = repository;
    }

    public QuestionDto GetNextQuestion(int studentId) => QuestionMediator.CreateDto(_repository.GetCurrentQuestion(studentId));
    public QuestionDto SaveAnswer(int studentId, string answer)
    {
        return QuestionMediator.CreateDto(
            _repository.UpdateCurrentQuestion(studentId,
                _repository.GetCurrentQuestion(studentId)
                    .Answer(answer), answer));
    }

    public string ListOfQuestionAnswers(int studentId)
    {
        return _repository.GetListOfAnswered(studentId);
    }
}
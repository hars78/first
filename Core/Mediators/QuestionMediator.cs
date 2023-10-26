using Core.Domain;
using Core.Dtos;

namespace Core.Mediators;

public static class QuestionMediator
{
    public static QuestionDto CreateDto(IQuestion question) => new (question.Print());
}
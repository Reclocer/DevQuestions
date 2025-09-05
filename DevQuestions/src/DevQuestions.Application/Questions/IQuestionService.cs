using CSharpFunctionalExtensions;
using DtoQuestion.Contracts;
using SubSystems;

namespace DevQuestions.Application.Questions;

public interface IQuestionsService
{
    Task<Result<Guid, Failure>> Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);
}
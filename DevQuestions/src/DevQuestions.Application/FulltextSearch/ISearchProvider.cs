using CSharpFunctionalExtensions;
using DevQuections.Domain.Questions;
using SubSystems;

namespace DevQuestions.Application.FulltextSearch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);
    Task<UnitResult<Failure>> IndexQuestionAsync(Question question);
}
using CSharpFunctionalExtensions;
using DevQuections.Domain.Questions;
using DevQuestions.Application.FulltextSearch;
using SubSystems;

namespace DevQuestion.Infrastructure.ElasticSearch;

public class ElastickSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query) => throw new NotImplementedException();

    public async Task<UnitResult<Failure>> IndexQuestionAsync(Question question)
    {
        try
        {

        }
        catch (Exception e)
        {
            return Error.Failure("search.error", e.Message).ToFailure();
        }
        
        return UnitResult.Success<Failure>();
    }
}
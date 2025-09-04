using DevQuestions.Application.FulltextSearch;

namespace DevQuestion.Infrastructure.ElasticSearch;

public class ElastickSearchProvider : ISearchProvider
{
    public Task<List<Guid>> SearchAsync(string query) => throw new NotImplementedException();
}
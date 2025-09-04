namespace DevQuestions.Application.FulltextSearch;

public interface ISearchProvider
{
    Task<List<Guid>> SearchAsync(string query);
}
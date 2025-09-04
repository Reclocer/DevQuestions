using DevQuestion.Infrastructure.PostgresSql.Repositories;
using DevQuestions.Application.Questions;
using Microsoft.Extensions.DependencyInjection;

namespace DevQuestion.Infrastructure.PostgresSql;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgresInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<QuestionsDbContext>();
        services.AddScoped<IQuestionsRepository, QuestionsEfCoreRepository>();
        
        return services;
    }
}
using DevQuestion.Infrastructure.PostgresSql;
using DevQuestions.Application;

namespace DevQuestionsWeb;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependencies(this IServiceCollection services)
    {
        services
            .AddWebDependencies()
            .AddApplication()
            .AddPostgresInfrastructure();
        
        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        return services;
    }
}
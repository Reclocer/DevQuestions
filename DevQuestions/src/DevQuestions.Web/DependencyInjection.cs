using DevQuestions.Application;
using FluentValidation;

namespace DevQuestions.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddProgramDependen(this IServiceCollection services)
    {
        services
            .AddWebDependencies()
            .AddApplication();
        
        return services;
    }

    private static IServiceCollection AddWebDependencies(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddOpenApi();
        return services;
    }
}
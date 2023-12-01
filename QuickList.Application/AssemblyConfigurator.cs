using Microsoft.Extensions.DependencyInjection;
using QuickList.Application.Services;
using QuickList.Domain.GoalAggregate;

namespace QuickList.Application;

public static class AssemblyConfigurator
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IGoalService, GoalService>();
        return services;
    }
}
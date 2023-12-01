using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickList.Domain.GoalAggregate;
using QuickList.Infrastructure.DataAccess;
using QuickList.Infrastructure.DataAccess.DataSources;
using QuickList.Infrastructure.DataAccess.Repositories;

namespace QuickList.Infrastructure;

public static class AssemblyConfigurator
{
    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<QuickListContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("QuickListDbConnectionString")));

        services.AddTransient<IGoalDataSource, GoalDataSource>();

        services.AddTransient<IGoalRepository, GoalRepository>();

        return services;
    }
}
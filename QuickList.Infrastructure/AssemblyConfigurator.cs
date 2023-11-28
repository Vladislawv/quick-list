using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickList.Infrastructure.DataAccess;

namespace QuickList.Infrastructure;

public static class AssemblyConfigurator
{
    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<QuickListContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("QuickListDbConnectionString")));

        return services;
    }
}
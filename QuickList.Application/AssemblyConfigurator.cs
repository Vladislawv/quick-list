using Microsoft.Extensions.DependencyInjection;

namespace QuickList.Application;

public static class AssemblyConfigurator
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(AssemblyConfigurator).Assembly));
        return services;
    }
}
using Microsoft.EntityFrameworkCore;
using QuickList.DataAccess;

namespace QuickList;

public static class AssemblyConfigurator
{
    public static IServiceCollection ConfigureWebApiServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();
        return services;
    }

    public static IServiceCollection ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<QuickListContext>(opt => 
            opt.UseNpgsql(configuration.GetConnectionString("QuickListDbConnectionString")));

        return services;
    }

    public static WebApplication UseWebApi(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        return app;
    }
}
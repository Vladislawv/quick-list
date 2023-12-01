using QuickList.Application;
using QuickList.Infrastructure;
using QuickList.MVC;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureWebApiServices()
    .ConfigureApplicationServices()
    .ConfigureInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureWebApi();

app.Run();
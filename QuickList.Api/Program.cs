using QuickList.Api;
using QuickList.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureWebApiServices()
    .ConfigureInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.ConfigureWebApi();

app.Run();
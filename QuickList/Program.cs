using QuickList;
using QuickList.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureWebApiServices()
    .ConfigureInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseWebApi();

app.Run();
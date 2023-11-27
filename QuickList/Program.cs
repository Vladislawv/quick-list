using QuickList;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureWebApiServices();

var app = builder.Build();

app.UseWebApi();

app.Run();
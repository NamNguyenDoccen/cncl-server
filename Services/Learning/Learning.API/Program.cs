using Learning.API;

var builder = WebApplication.CreateBuilder(args);

builder.AddModules();

var app = builder.Build();

app.UseModules();

app.Run();
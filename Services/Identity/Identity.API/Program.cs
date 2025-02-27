using Identity.API;

var builder = WebApplication.CreateBuilder(args);

builder.AddModules(builder.Configuration);

var app = builder.Build();

app.UseModules();

app.Run();
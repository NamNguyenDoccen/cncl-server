using Asp.Versioning.Conventions;
using FluentValidation;
using Learning.API.Endpoints;
using System.Reflection;

namespace Learning.API;

public static class Extensions
{
    public static WebApplicationBuilder AddModules(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddOpenApi();

        // Add API versioning services
        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
        });

        // define module assemblies
        var assemblies = new[]
        {
            Assembly.GetExecutingAssembly(), // Learning.API
            Assembly.Load("Learning.Application") // Learning.Application
        };
        builder.Services.AddValidatorsFromAssemblies(assemblies);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

        return builder;
    }

    public static WebApplication UseModules(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        //register api versions
        var versions = app.NewApiVersionSet()
            .HasApiVersion(1)
            .HasApiVersion(2)
            .ReportApiVersions()
            .Build();

        var endpoints = app.MapGroup("api/v{version:apiVersion}").WithApiVersionSet(versions);

        // mapping endpoints
        endpoints.MapLearningEndpoints();

        return app;
    }
}
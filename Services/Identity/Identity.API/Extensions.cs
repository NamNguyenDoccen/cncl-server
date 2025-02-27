using Identity.API.Endpoints;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Services.OpenApi;

namespace Identity.API;

public static class Extensions
{
    public static WebApplicationBuilder AddModules(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddOpenApi();

        //builder.AddServiceDefaults();
        //builder.ConfigureSerilog();
        builder.Services.ConfigureDatabase(configuration);
        //builder.Services.ConfigureMultitenancy();
        builder.Services.ConfigureIdentity();
        //builder.Services.AddCorsPolicy(builder.Configuration);
        //builder.Services.ConfigureFileStorage();
        //builder.Services.ConfigureJwtAuth();
        builder.Services.ConfigureOpenApi();
        //builder.Services.ConfigureJobs(builder.Configuration);
        //builder.Services.ConfigureMailing();
        //builder.Services.ConfigureCaching(builder.Configuration);
        //builder.Services.AddExceptionHandler<CustomExceptionHandler>();
        //builder.Services.AddProblemDetails();
        //builder.Services.AddHealthChecks();
        //builder.Services.AddOptions<OriginOptions>().BindConfiguration(nameof(OriginOptions));
        return builder;
    }

    public static WebApplication UseModules(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);
        app.UseOpenApi();
        app.MapIdentityEndpoints();
        return app;
    }
}
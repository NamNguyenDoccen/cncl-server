using Core.Audit;
using Core.Persistence;
using Identity.Application.Interfaces.Roles;
using Identity.Application.Interfaces.Tokens;
using Identity.Application.Interfaces.Users;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence.Interceptors;
using Identity.Infrastructure.Persistence.Middlewares.Users;
using Identity.Infrastructure.Services.Audit;
using Identity.Infrastructure.Services.Roles;
using Identity.Infrastructure.Services.Tokens;
using Identity.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using IdentityConstants = Identity.Application.Common.Constants.IdentityConstants;

namespace Identity.Infrastructure.Persistence;

public static class Extensions
{
    public static IServiceCollection BindDbContext<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddDbContext<TContext>((sp, options) =>
        {
            var dbConfig = sp.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            options.UseDatabase(dbConfig.Provider, dbConfig.ConnectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        return services;
    }

    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOptions<DatabaseOptions>()
            .Bind(configuration.GetSection(nameof(DatabaseOptions)))
            .ValidateDataAnnotations()
            .PostConfigure(config =>
            {
                //TODO: Logger.Information("current db provider: {DatabaseProvider}", config.Provider);
            });

        services.AddScoped<ISaveChangesInterceptor, AuditInterceptor>();

        return services;
    }

    public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<CurrentUserMiddleware>();
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IAuditService, AuditService>();
        services.BindDbContext<IdentityDbContext>();
        services.AddScoped<IDbInitializer, IdentityDbInitializer>();
        services.AddIdentity<CnclUser, CnclRole>(options =>
            {
                options.Password.RequiredLength = IdentityConstants.PasswordMinLength;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
           .AddEntityFrameworkStores<IdentityDbContext>()
           .AddDefaultTokenProviders();

        return services;
    }

    public static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder optionsBuilder, string dbProvider, string connectionString)
    {
        return dbProvider.ToUpperInvariant() switch
        {
            DbProviders.PostgreSQL => optionsBuilder.UseNpgsql(connectionString), // TODO: Compare with FSH.Framework.Infrastructure.Persistence.Extensions
            _ => throw new InvalidOperationException($"Database provider '{dbProvider}' is not supported.")
        };
    }
}
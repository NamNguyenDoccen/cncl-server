using EasyCaching.Core.Configurations;
using EasyCaching.Serialization.SystemTextJson.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Caching;

public static class Startup
{
    public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheSettings = configuration.GetSection(nameof(CacheSettings)).Get<CacheSettings>()
            ?? throw new Exception("CacheSettings not found in configuration");

        services.AddEasyCaching(options =>
        {
            options.UseRedis(redisConfig =>
            {
                redisConfig.DBConfig.Endpoints.Add(new ServerEndPoint(cacheSettings.RedisUrl, 6379));
                redisConfig.DBConfig.AllowAdmin = true;
                redisConfig.DBConfig.ConnectionTimeout = 10000;
                redisConfig.DBConfig.SyncTimeout = 10000;
                redisConfig.SerializerName = "json";
            });

            options.WithSystemTextJson(config =>
            {
                config.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                config.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                config.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            }, "json");
        });

        services.AddScoped<ICacheService, DistributedCacheService>();

        return services;
    }
}
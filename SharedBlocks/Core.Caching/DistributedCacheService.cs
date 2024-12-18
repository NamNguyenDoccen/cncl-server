using EasyCaching.Core;
using Microsoft.Extensions.Logging;

namespace Core.Caching;

public class DistributedCacheService(IEasyCachingProvider cachingProvider, ILogger<DistributedCacheService> logger) : ICacheService
{
    public bool Exists(string key)
    {
        logger.LogInformation("Checking if key {Key} exists in cache", key);
        return cachingProvider.Exists(key);
    }

    public async Task<bool> ExistsAsync(string key, CancellationToken ct)
    {
        logger.LogInformation("Checking if key {Key} exists in cache", key);
        return await cachingProvider.ExistsAsync(key, ct);
    }

    public T? Get<T>(string key)
    {
        try
        {
            logger.LogInformation("Getting value for key {Key} from cache", key);
            return cachingProvider.Get<T>(key).Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting value for key {Key} from cache", key);
            Remove(key);
            return default;
        }
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken ct)
    {
        try
        {
            logger.LogInformation("Getting value for key {Key} from cache", key);
            var cacheValue = await cachingProvider.GetAsync<T>(key, ct);
            return cacheValue.HasValue ? cacheValue.Value : default;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting value for key {Key} from cache", key);
            await RemoveAsync(key, ct);
            return default;
        }
    }

    public T? GetOrSet<T>(string key, Func<T> valueFactory, TimeSpan expiration)
    {
        try
        {
            logger.LogInformation("Getting or setting value for key {Key} from cache", key);
            var value = Get<T>(key);
            if (value is not null)
            {
                return value;
            }

            value = valueFactory();
            if (value is not null)
            {
                Set(key, value, expiration);
            }

            return value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting or setting value for key {Key} from cache", key);
            Remove(key);
            return default;
        }
    }

    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, TimeSpan expiration, CancellationToken ct)
    {
        try
        {
            logger.LogInformation("Getting or setting value for key {Key} from cache", key);
            var value = await GetAsync<T>(key, ct);
            if (value is not null)
            {
                return value;
            }
            value = await valueFactory();
            if (value is not null)
            {
                _ = SetAsync(key, value, expiration, ct);
            }
            return value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting or setting value for key {Key} from cache", key);
            await RemoveAsync(key, ct);
            return default;
        }
    }

    public void Remove(string key)
    {
        logger.LogInformation("Removing key {Key} from cache", key);
        cachingProvider.Remove(key);
    }

    public Task RemoveAsync(string key, CancellationToken ct)
    {
        logger.LogInformation("Removing key {Key} from cache", key);
        return cachingProvider.RemoveAsync(key, ct);
    }

    public void RemoveByPattern(string pattern)
    {
        logger.LogInformation("Removing keys by pattern {Pattern} from cache", pattern);
        cachingProvider.RemoveByPattern(pattern);
    }

    public Task RemoveByPatternAsync(string pattern, CancellationToken ct)
    {
        logger.LogInformation("Removing keys by pattern {Pattern} from cache", pattern);
        return cachingProvider.RemoveByPatternAsync(pattern, ct);
    }

    public void RemoveByPrefix(string prefix)
    {
        logger.LogInformation("Removing keys by prefix {Prefix} from cache", prefix);
        cachingProvider.RemoveByPrefix(prefix);
    }

    public Task RemoveByPrefixAsync(string prefix, CancellationToken ct)
    {
        logger.LogInformation("Removing keys by prefix {Prefix} from cache", prefix);
        return cachingProvider.RemoveByPrefixAsync(prefix, ct);
    }

    public void Set<T>(string key, T value, TimeSpan expiration)
    {
        logger.LogInformation("Setting value for key {Key} in cache", key);
        cachingProvider.Set(key, value, expiration);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expiration, CancellationToken ct)
    {
        logger.LogInformation("Setting value for key {Key} in cache", key);
        return cachingProvider.SetAsync(key, value, expiration, ct);
    }
}
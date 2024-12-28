namespace Core.Caching;

public interface ICacheService
{
    bool Exists(string key);

    Task<bool> ExistsAsync(string key, CancellationToken ct);

    T? Get<T>(string key);

    Task<T?> GetAsync<T>(string key, CancellationToken ct);

    T? GetOrSet<T>(string key, Func<T> valueFactory, TimeSpan expiration);

    Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, TimeSpan expiration, CancellationToken ct);

    void Remove(string key);

    Task RemoveAsync(string key, CancellationToken ct);

    void RemoveByPattern(string pattern);

    Task RemoveByPatternAsync(string pattern, CancellationToken ct);

    void RemoveByPrefix(string prefix);

    Task RemoveByPrefixAsync(string prefix, CancellationToken ct);

    void Set<T>(string key, T value, TimeSpan expiration);

    Task SetAsync<T>(string key, T value, TimeSpan expiration, CancellationToken ct);
}
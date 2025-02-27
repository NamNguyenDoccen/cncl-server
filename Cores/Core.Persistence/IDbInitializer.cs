namespace Core.Persistence;

public interface IDbInitializer
{
    Task MigrateAsync(CancellationToken ct);

    Task SeedAsync(CancellationToken ct);
}
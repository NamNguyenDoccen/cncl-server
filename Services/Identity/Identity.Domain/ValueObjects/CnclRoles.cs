using System.Collections.ObjectModel;

namespace Identity.Domain.ValueObjects;

public static class CnclRoles
{
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(
    [
        Admin,
        Basic
    ]);

    public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
}
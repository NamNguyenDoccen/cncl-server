using System.Collections.ObjectModel;

namespace Identity.Domain.ValueObjects;

public static class CnclPermissions
{
    private static readonly CnclPermission[] AllPermissions =
    [
        //identity
        new("View Users", CnclActions.View, CnclResources.Users),
        new("Search Users", CnclActions.Search, CnclResources.Users),
        new("Create Users", CnclActions.Create, CnclResources.Users),
        new("Update Users", CnclActions.Update, CnclResources.Users),
        new("Delete Users", CnclActions.Delete, CnclResources.Users),
        new("Export Users", CnclActions.Export, CnclResources.Users),
        new("View UserRoles", CnclActions.View, CnclResources.UserRoles),
        new("Update UserRoles", CnclActions.Update, CnclResources.UserRoles),
        new("View Roles", CnclActions.View, CnclResources.Roles),
        new("Create Roles", CnclActions.Create, CnclResources.Roles),
        new("Update Roles", CnclActions.Update, CnclResources.Roles),
        new("Delete Roles", CnclActions.Delete, CnclResources.Roles),
        new("View RoleClaims", CnclActions.View, CnclResources.RoleClaims),
        new("Update RoleClaims", CnclActions.Update, CnclResources.RoleClaims),

        new("View Hangfire", CnclActions.View, CnclResources.Hangfire),
        new("View Dashboard", CnclActions.View, CnclResources.Dashboard),

        //audit
        new("View Audit Trails", CnclActions.View, CnclResources.AuditTrails),
    ];

    public static IReadOnlyList<CnclPermission> Admin { get; } = new ReadOnlyCollection<CnclPermission>(AllPermissions.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<CnclPermission> All { get; } = new ReadOnlyCollection<CnclPermission>(AllPermissions);
    public static IReadOnlyList<CnclPermission> Basic { get; } = new ReadOnlyCollection<CnclPermission>(AllPermissions.Where(p => p.IsBasic).ToArray());
    public static IReadOnlyList<CnclPermission> Root { get; } = new ReadOnlyCollection<CnclPermission>(AllPermissions.Where(p => p.IsRoot).ToArray());
}

public record CnclPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource)
    {
        return $"Permissions.{resource}.{action}";
    }
}
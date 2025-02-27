namespace Identity.Application.Features.Roles.UpdatePermissions;

public class UpdatePermissionsCommand
{
    public List<string> Permissions { get; set; } = default!;
    public string RoleId { get; set; } = default!;
}
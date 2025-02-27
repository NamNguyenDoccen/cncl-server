namespace Identity.Application.Features.Roles.CreateOrUpdateRole;

public class CreateOrUpdateRoleCommand
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

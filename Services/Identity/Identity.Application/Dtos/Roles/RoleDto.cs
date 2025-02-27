namespace Identity.Application.Dtos.Roles;

public class RoleDto
{
    public string? Description { get; set; }
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public List<string>? Permissions { get; set; }
}
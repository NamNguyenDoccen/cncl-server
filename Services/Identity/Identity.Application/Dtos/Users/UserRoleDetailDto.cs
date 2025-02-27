namespace Identity.Application.Dtos.Users;

public class UserRoleDetailDto
{
    public string? Description { get; set; }
    public bool Enabled { get; set; }
    public string? RoleId { get; set; }
    public string? RoleName { get; set; }
}
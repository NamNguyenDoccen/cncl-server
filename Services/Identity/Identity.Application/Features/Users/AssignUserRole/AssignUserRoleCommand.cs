using Identity.Application.Dtos.Users;

namespace Identity.Application.Features.Users.AssignUserRole;

public class AssignUserRoleCommand
{
    public List<UserRoleDetailDto> UserRoles { get; set; } = [];
}
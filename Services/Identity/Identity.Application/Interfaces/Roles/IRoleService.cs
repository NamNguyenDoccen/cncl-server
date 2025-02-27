using Identity.Application.Dtos.Roles;
using Identity.Application.Features.Roles.CreateOrUpdateRole;
using Identity.Application.Features.Roles.UpdatePermissions;

namespace Identity.Application.Interfaces.Roles;

public interface IRoleService
{
    Task<RoleDto> CreateOrUpdateRoleAsync(CreateOrUpdateRoleCommand command);

    Task DeleteRoleAsync(string id);

    Task<RoleDto?> GetRoleAsync(string id);

    Task<IEnumerable<RoleDto>> GetRolesAsync();

    Task<RoleDto> GetWithPermissionsAsync(string id, CancellationToken ct);

    Task<string> UpdatePermissionsAsync(UpdatePermissionsCommand request);
}
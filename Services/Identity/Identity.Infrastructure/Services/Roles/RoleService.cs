using Identity.Application.Dtos.Roles;
using Identity.Application.Features.Roles.CreateOrUpdateRole;
using Identity.Application.Features.Roles.UpdatePermissions;
using Identity.Application.Interfaces.Roles;

namespace Identity.Infrastructure.Services.Roles;

public class RoleService : IRoleService
{
    public Task<RoleDto> CreateOrUpdateRoleAsync(CreateOrUpdateRoleCommand command)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRoleAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<RoleDto?> GetRoleAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RoleDto>> GetRolesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<RoleDto> GetWithPermissionsAsync(string id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdatePermissionsAsync(UpdatePermissionsCommand request)
    {
        throw new NotImplementedException();
    }
}
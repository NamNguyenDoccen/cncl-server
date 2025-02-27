using Identity.Application.Dtos.Users;
using Identity.Application.Features.Users.ForgotPassword;
using System.Security.Claims;

namespace Identity.Infrastructure.Services.Users;

public sealed partial class UserService
{
    public Task ForgotPasswordAsync(ForgotPasswordCommand request, string origin, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UserDetailDto> GetAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDetailDto>> GetListAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetOrCreateFromPrincipalAsync(ClaimsPrincipal principal)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>?> GetPermissionsAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserRoleDetailDto>> GetUserRolesAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
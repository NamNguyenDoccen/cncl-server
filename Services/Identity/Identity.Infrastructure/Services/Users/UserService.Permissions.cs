using Identity.Application.Features.Users.RegisterUser;
using Identity.Application.Features.Users.ResetPassword;
using Identity.Application.Features.Users.ToggleUserStatus;
using Identity.Application.Features.Users.UpdateUser;

namespace Identity.Infrastructure.Services.Users;

public sealed partial class UserService
{
    public Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<RegisterUserResponse> RegisterAsync(RegisterUserCommand request, string origin, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task ResetPasswordAsync(ResetPasswordCommand request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task ToggleStatusAsync(ToggleUserStatusCommand request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateUserCommand request, string userId)
    {
        throw new NotImplementedException();
    }
}
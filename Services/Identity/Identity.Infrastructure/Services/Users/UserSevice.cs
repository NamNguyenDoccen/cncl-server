using Identity.Application.Features.Users.AssignUserRole;
using Identity.Application.Features.Users.ChangePassword;
using Identity.Application.Interfaces.Users;

namespace Identity.Infrastructure.Services.Users;

public sealed partial class UserService : IUserService
{
    public Task<string> AssignRolesAsync(string userId, AssignUserRoleCommand request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task ChangePasswordAsync(ChangePasswordCommand request, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<string> ConfirmEmailAsync(string userId, string code, string tenant, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<string> ConfirmPhoneNumberAsync(string userId, string code)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null)
    {
        throw new NotImplementedException();
    }
}
using Identity.Application.Dtos.Users;
using Identity.Application.Features.Users.AssignUserRole;
using Identity.Application.Features.Users.ChangePassword;
using Identity.Application.Features.Users.ForgotPassword;
using Identity.Application.Features.Users.RegisterUser;
using Identity.Application.Features.Users.ResetPassword;
using Identity.Application.Features.Users.ToggleUserStatus;
using Identity.Application.Features.Users.UpdateUser;
using System.Security.Claims;

namespace Identity.Application.Interfaces.Users;

public interface IUserService
{
    Task<string> AssignRolesAsync(string userId, AssignUserRoleCommand request, CancellationToken ct);

    Task ChangePasswordAsync(ChangePasswordCommand request, string userId);

    Task<string> ConfirmEmailAsync(string userId, string code, string tenant, CancellationToken ct);

    Task<string> ConfirmPhoneNumberAsync(string userId, string code);

    Task DeleteAsync(string userId);

    Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null);

    Task<bool> ExistsWithNameAsync(string name);

    Task<bool> ExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null);

    // passwords
    Task ForgotPasswordAsync(ForgotPasswordCommand request, string origin, CancellationToken ct);

    Task<UserDetailDto> GetAsync(string userId, CancellationToken ct);

    Task<int> GetCountAsync(CancellationToken ct);

    Task<List<UserDetailDto>> GetListAsync(CancellationToken ct);

    Task<string> GetOrCreateFromPrincipalAsync(ClaimsPrincipal principal);

    Task<List<string>?> GetPermissionsAsync(string userId, CancellationToken ct);

    Task<List<UserRoleDetailDto>> GetUserRolesAsync(string userId, CancellationToken ct);

    // permisions
    Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken ct = default);

    Task<RegisterUserResponse> RegisterAsync(RegisterUserCommand request, string origin, CancellationToken ct);

    Task ResetPasswordAsync(ResetPasswordCommand request, CancellationToken ct);

    Task ToggleStatusAsync(ToggleUserStatusCommand request, CancellationToken ct);

    Task UpdateAsync(UpdateUserCommand request, string userId);
}
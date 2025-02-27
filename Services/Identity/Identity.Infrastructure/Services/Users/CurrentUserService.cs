using Core.Exceptions;
using Identity.Application.Common.Extensions;
using Identity.Application.Interfaces.Users;
using System.Security.Claims;

namespace Identity.Infrastructure.Services.Users;

public class CurrentUser : ICurrentUser, ICurrentUserInitializer
{
    private ClaimsPrincipal? _user;
    private Guid _userId = Guid.Empty;
    public string? Name => _user?.Identity?.Name;

    public IEnumerable<Claim>? GetUserClaims() => _user?.Claims;

    public string? GetUserEmail() => IsAuthenticated() ? _user!.GetEmail() : string.Empty;

    public Guid GetUserId() => IsAuthenticated() ? Guid.Parse(_user?.GetUserId() ?? Guid.Empty.ToString()) : _userId;

    public bool IsAuthenticated() => _user?.Identity?.IsAuthenticated is true;

    public bool IsInRole(string role) => _user?.IsInRole(role) is true;

    public void SetCurrentUser(ClaimsPrincipal user)
    {
        if (_user != null)
        {
            throw new CnclException("Method reserved for in-scope initialization");
        }

        _user = user;
    }

    public void SetCurrentUserId(string userId)
    {
        if (_userId != Guid.Empty)
        {
            throw new CnclException("Method reserved for in-scope initialization");
        }

        if (!string.IsNullOrEmpty(userId))
        {
            _userId = Guid.Parse(userId);
        }
    }
}
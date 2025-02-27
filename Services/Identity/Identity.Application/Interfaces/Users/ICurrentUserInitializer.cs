using System.Security.Claims;

namespace Identity.Application.Interfaces.Users;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(string userId);
}
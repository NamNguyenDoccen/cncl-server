using Identity.Application.Interfaces.Users;
using Microsoft.AspNetCore.Http;

namespace Identity.Infrastructure.Persistence.Middlewares.Users;

public class CurrentUserMiddleware(ICurrentUserInitializer currentUserInitializer) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        currentUserInitializer.SetCurrentUser(context.User);
        await next(context);
    }
}
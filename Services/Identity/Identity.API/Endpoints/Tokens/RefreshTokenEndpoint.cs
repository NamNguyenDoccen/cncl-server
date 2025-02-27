using Identity.Application.Features.Tokens.Refresh;
using Identity.Application.Interfaces.Tokens;

namespace Identity.API.Endpoints.Tokens;

public static class RefreshTokenEndpoint
{
    public static RouteHandlerBuilder MapRefreshTokenEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/refresh", (RefreshTokenCommand request,
           ITokenService service,
           HttpContext context,
           CancellationToken cancellationToken) =>
        {
            string ip = context.GetIpAddress();
            return service.RefreshTokenAsync(request, ip!, cancellationToken);
        })
       .WithName(nameof(RefreshTokenEndpoint))
       .WithSummary("refresh JWTs")
       .WithDescription("refresh JWTs")
       .AllowAnonymous();
    }
}
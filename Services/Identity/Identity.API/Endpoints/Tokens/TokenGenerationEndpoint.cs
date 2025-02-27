using Identity.Application.Features.Tokens.Create;
using Identity.Application.Interfaces.Tokens;

namespace Identity.API.Endpoints.Tokens;

public static class TokenGenerationEndpoint
{
    // write extension method for IEndpointRouteBuilder
    public static RouteHandlerBuilder MapTokenGenerationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints.MapPost("/", (TokenGenerationCommand request,
            ITokenService service,
            HttpContext context,
            CancellationToken cancellationToken) =>
        {
            string ip = context.GetIpAddress();
            return service.GenerateTokenAsync(request, ip!, cancellationToken);
        })
        .WithName(nameof(TokenGenerationEndpoint))
        .WithSummary("generate JWTs")
        .WithDescription("generate JWTs")
        .AllowAnonymous();
    }
}
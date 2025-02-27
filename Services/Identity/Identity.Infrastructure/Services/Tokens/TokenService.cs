using Identity.Application.Features.Tokens.Create;
using Identity.Application.Features.Tokens.Refresh;
using Identity.Application.Interfaces.Tokens;
using Identity.Domain.ValueObjects;

namespace Identity.Infrastructure.Services.Tokens;

public sealed class TokenService : ITokenService
{
    public Task<CnclToken> GenerateTokenAsync(TokenGenerationCommand request, string ipAddress, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<CnclToken> RefreshTokenAsync(RefreshTokenCommand request, string ipAddress, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
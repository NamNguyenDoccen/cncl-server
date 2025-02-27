using Identity.Application.Features.Tokens.Create;
using Identity.Application.Features.Tokens.Refresh;
using Identity.Domain.ValueObjects;

namespace Identity.Application.Interfaces.Tokens;

public interface ITokenService
{
    Task<CnclToken> GenerateTokenAsync(TokenGenerationCommand request, string ipAddress, CancellationToken ct);

    Task<CnclToken> RefreshTokenAsync(RefreshTokenCommand request, string ipAddress, CancellationToken ct);
}
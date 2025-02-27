namespace Identity.Application.Features.Tokens.Refresh;

public record RefreshTokenCommand(string Token, string RefreshToken);
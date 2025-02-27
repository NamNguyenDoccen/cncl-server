namespace Identity.Domain.ValueObjects;

public record CnclToken(string Token, string RefreshToken, DateTime RefreshTokenExpiryTime);
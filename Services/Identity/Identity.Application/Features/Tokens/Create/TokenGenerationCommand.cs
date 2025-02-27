namespace Identity.Application.Features.Tokens.Create;

public record TokenGenerationCommand(string UserIdentifier, string Password);
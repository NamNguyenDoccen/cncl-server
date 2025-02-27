using FluentValidation;

namespace Identity.Application.Features.Tokens.Create;

public class TokenGenerationValidator : AbstractValidator<TokenGenerationCommand>
{
    public TokenGenerationValidator()
    {
        RuleFor(x => x.UserIdentifier)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("UserIdentifier is required.")
            .EmailAddress().WithMessage("UserIdentifier is not valid.");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Password is required.");
    }
}
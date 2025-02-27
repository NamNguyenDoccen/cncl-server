using FluentValidation;

namespace Identity.Application.Features.Tokens.Refresh;

public class RefreshTokenValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x.Token).Cascade(CascadeMode.Stop).NotEmpty();

        RuleFor(x => x.RefreshToken).Cascade(CascadeMode.Stop).NotEmpty();
    }
}
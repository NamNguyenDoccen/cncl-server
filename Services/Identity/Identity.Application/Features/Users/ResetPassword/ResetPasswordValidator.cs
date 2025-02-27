using FluentValidation;
using Identity.Application.Common.Constants;

namespace Identity.Application.Features.Users.ResetPassword;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(IdentityConstants.PasswordMinLength).WithMessage($"Password must be at least {IdentityConstants.PasswordMinLength} characters.");
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Token is required.");
    }
}
using FluentValidation;
using Identity.Application.Common.Constants;

namespace Identity.Application.Features.Users.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(IdentityConstants.PasswordMinLength).WithMessage($"Password must not be less than {IdentityConstants.PasswordMinLength} characters.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(IdentityConstants.PasswordMinLength).WithMessage($"Password must not be less than {IdentityConstants.PasswordMinLength} characters.");

        RuleFor(x => x.ConfirmNewPassword)
            .Equal(x => x.NewPassword).WithMessage("Passwords do not match.");
    }
}
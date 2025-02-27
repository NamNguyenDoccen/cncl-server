using FluentValidation;

namespace Identity.Application.Features.Roles.CreateOrUpdateRole;

public class CreateOrUpdateRoleValidator : AbstractValidator<CreateOrUpdateRoleCommand>
{
    public CreateOrUpdateRoleValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required.");
    }
}
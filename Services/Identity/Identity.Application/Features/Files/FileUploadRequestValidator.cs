using FluentValidation;

namespace Identity.Application.Features.Files;

public class FileUploadRequestValidator : AbstractValidator<FileUploadCommand>
{
    public FileUploadRequestValidator()
    {
        RuleFor(v => v.Data)
            .NotEmpty().WithMessage("Data is required.");

        RuleFor(v => v.Extension)
            .NotEmpty().WithMessage("Extension is required.")
            .MaximumLength(5).WithMessage("Extension must not exceed 5 characters.");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(150).WithMessage("Name must not exceed 150 characters.");
    }
}
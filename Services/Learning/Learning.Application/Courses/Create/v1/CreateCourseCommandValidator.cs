using FluentValidation;

namespace Learning.Application.Courses.Create.v1;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(2);
    }
}
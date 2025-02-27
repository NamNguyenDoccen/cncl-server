using MediatR;

namespace Learning.Application.Courses.Create.v1;

public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
{
    public Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(request);
        return Task.FromResult(new CreateCourseResponse(Guid.NewGuid()));
    }
}
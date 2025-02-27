using MediatR;

namespace Learning.Application.Courses.Get.v1;

public class GetCourseHandler() : IRequestHandler<GetCourseQuery, GetCourseResponse>
{
    public Task<GetCourseResponse> Handle(GetCourseQuery request, CancellationToken ct)
    {
        return Task.FromResult(new GetCourseResponse(Guid.NewGuid(), "Course Title"));
    }
}
using MediatR;

namespace Learning.Application.Courses.Get.v1;

public sealed record GetCourseQuery(Guid Id) : IRequest<GetCourseResponse>;
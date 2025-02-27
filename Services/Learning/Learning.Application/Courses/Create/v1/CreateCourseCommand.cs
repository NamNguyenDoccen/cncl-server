using MediatR;

namespace Learning.Application.Courses.Create.v1;

public sealed record CreateCourseCommand(string Title) : IRequest<CreateCourseResponse>;
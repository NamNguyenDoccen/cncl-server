using Learning.Application.Courses.Get.v1;
using MediatR;

namespace Learning.API.Endpoints.v1;

public static class GetCourseEndpoint
{
    internal static void MapGetCourseEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/{id}", async (Guid id, ISender mediator, CancellationToken ct) =>
        {
            var response = await mediator.Send(new GetCourseQuery(id), ct);
            return Results.Ok(response);
        })
        .WithName(nameof(GetCourseEndpoint))
        .WithSummary("Gets a course by ID.")
        .WithDescription("Gets a course by ID.")
        .Produces<GetCourseResponse>()
        //.RequirePermission("Permissions.Courses.View")
        .MapToApiVersion(1);
    }
}
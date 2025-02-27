using Learning.Application.Courses.Create.v1;
using MediatR;

namespace Learning.API.Endpoints.v1;

public static class CreateCourseEndpoint
{
    internal static void MapCreateCourseEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/", async (CreateCourseCommand request, ISender mediator, CancellationToken ct) =>
        {
            var response = await mediator.Send(request, ct);
            return Results.Ok(response);
        })
        .WithName(nameof(CreateCourseEndpoint))
        .WithSummary("Creates a new course.")
        .WithDescription("Creates a new course.")
        .Produces<CreateCourseResponse>(StatusCodes.Status201Created)
        //.RequirePermission("Permissions.Courses.Create") TODO: add permissions
        .MapToApiVersion(1);
    }
}
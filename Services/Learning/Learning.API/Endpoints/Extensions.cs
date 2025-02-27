using Learning.API.Endpoints.v1;

namespace Learning.API.Endpoints;

public static class Extensions
{
    public static void MapLearningEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var courseGroup = endpoints.MapGroup("courses").WithTags("Courses");

        // map v1 endpoints
        courseGroup.MapCreateCourseEndpoint();
        courseGroup.MapGetCourseEndpoint();
    }
}
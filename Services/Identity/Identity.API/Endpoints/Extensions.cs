using Identity.API.Endpoints.Tokens;

namespace Identity.API.Endpoints;

public static class Extensions
{
    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder app)
    {
        //TODO
        //var users = app.MapGroup("api/users").WithTags("users");
        //users.MapUserEndpoints();

        var tokens = app.MapGroup("api/token").WithTags("token");
        tokens.MapTokenEndpoints();

        //var roles = app.MapGroup("api/roles").WithTags("roles");
        //roles.MapRoleEndpoints();

        return app;
    }
}
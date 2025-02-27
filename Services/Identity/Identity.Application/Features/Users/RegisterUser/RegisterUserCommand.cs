using MediatR;
using System.Text.Json.Serialization;

namespace Identity.Application.Features.Users.RegisterUser;

public class RegisterUserCommand : IRequest<RegisterUserResponse>
{
    public string ConfirmPassword { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    [JsonIgnore]
    public string? Origin { get; set; }

    public string Password { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string UserName { get; set; } = default!;
}
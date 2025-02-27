using Identity.Application.Features.Files;
using MediatR;

namespace Identity.Application.Features.Users.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public bool DeleteCurrentImage { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string Id { get; set; } = default!;
    public FileUploadCommand? Image { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
}
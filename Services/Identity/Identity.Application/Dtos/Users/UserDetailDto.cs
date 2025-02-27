namespace Identity.Application.Dtos.Users;

public class UserDetailDto
{
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? FirstName { get; set; }
    public Guid Id { get; set; }

    public Uri? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
}
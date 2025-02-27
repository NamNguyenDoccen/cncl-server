namespace Identity.Application.Features.Users.ToggleUserStatus;

public class ToggleUserStatusCommand
{
    public bool ActivateUser { get; set; }
    public string? UserId { get; set; }
}
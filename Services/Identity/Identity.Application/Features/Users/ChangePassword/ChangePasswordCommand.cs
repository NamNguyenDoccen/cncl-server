namespace Identity.Application.Features.Users.ChangePassword;

public class ChangePasswordCommand
{
    public string ConfirmNewPassword { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
    public string Password { get; set; } = default!;
}
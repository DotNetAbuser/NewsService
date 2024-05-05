namespace Shared.Contracts.Requests.Identity;

public class ChangePasswordRequest(string oldPassword,
    string newPassword, string confirmNewPassword)
{
    [Required]
    public string OldPassword { get; } = oldPassword;
    [Required]
    public string NewPassword { get; } = newPassword;
    [Required]
    [Compare(nameof(NewPassword))]
    public string ConfirmNewPassword { get; } = confirmNewPassword;
}
namespace Shared.Contracts.Requests.Identity;

public record TokenRequest(
    [Required] string Username,
    [Required] string Password);
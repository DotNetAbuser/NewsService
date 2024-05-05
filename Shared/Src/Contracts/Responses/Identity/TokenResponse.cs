namespace Shared.Contracts.Responses.Identity;

public record TokenResponse(
    [Required] string AuthToken,
    [Required] string RefreshToken);
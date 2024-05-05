namespace Shared.Contracts.Responses.Identity;

public record UserResponse(
    [Required] string ID,
    [Required] string ProfilePictureUrl,
    [Required] string LastName,
    [Required] string FirstName,
    [Required] string? MiddleName,
    [Required] string Username,
    [Required] string Email,
    [Required] string Phone,
    [Required] bool IsActive,
    [Required] DateTime Created);
namespace Shared.Contracts.Requests.Identity;

public record SignUpRequest(
    [Required] string LastName, 
    [Required] string FirstName,
    string? MiddleName,
    [Required] string Username,
    [Required] string Password,
    [Required] string ConfirmPassword,
    [Required] [EmailAddress] string Email,
    [Required] [Phone] string Phone);
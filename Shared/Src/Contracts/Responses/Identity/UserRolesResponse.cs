namespace Shared.Contracts.Responses.Identity;

public class UserRolesResponse
{
    public List<UserRole> UserRoles { get; set; } = [];
}

public record UserRole(
    [Required] string Name,
    bool Selected);
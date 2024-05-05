namespace Shared.Contracts.Requests.Identity;

public class UpdateUserRolesRequest
{
    public List<UserRole> UserRoles { get; set; } = [];
}
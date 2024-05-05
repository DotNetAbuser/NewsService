using Shared.Contracts;
using Shared.Contracts.Requests.Identity;
using Shared.Contracts.Responses.Identity;

namespace Shared.IServices;

public interface IUserService
{
    Task<Result<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);
    
    Task<Result> CreateAsync(SignUpRequest request);

    Task<Result<UserRolesResponse>> GetRolesByIdAsync(string userId);
    Task<Result<UserResponse>> GetByIdAsync(string userId);
    Task<Result> UpdateRolesAsync(string userId, UpdateUserRolesRequest request);
    Task<Result> ToggleStatusAsync(string userId, ToggleUserStatusRequest request);
}
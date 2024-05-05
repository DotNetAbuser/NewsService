namespace Client.Infrastructure.Managers;

public interface IUserManager
{
    Task<IResult<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);
    
    Task<IResult> CreateAsync(SignUpRequest request);

    Task<IResult<UserRolesResponse>> GetRolesByIdAsync(string userId);
    Task<IResult<UserResponse>> GetByIdAsync(string userId);
    Task<IResult> UpdateRolesAsync(string userId, UpdateUserRolesRequest request);
    Task<IResult> ToggleStatusAsync(string userId, ToggleUserStatusRequest request);
}

public class UserManager(
    IHttpClientFactory _factory)
    : IUserManager
{
    public async Task<IResult<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(UserRoutes.GetPaginatedUser(
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<UserResponse>>();
    }

    public async Task<IResult> CreateAsync(SignUpRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PostAsJsonAsync(UserRoutes.SignUp, request);
        return await response.ToResult();
    }

    public async Task<IResult<UserRolesResponse>> GetRolesByIdAsync(string userId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(UserRoutes.GetRolesById(userId));
        return await response.ToResult<UserRolesResponse>();
    }

    public async Task<IResult<UserResponse>> GetByIdAsync(string userId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(UserRoutes.GetById(userId));
        return await response.ToResult<UserResponse>();
    }

    public async Task<IResult> UpdateRolesAsync(string userId, UpdateUserRolesRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(UserRoutes.UpdateRoles(userId), request);
        return await response.ToResult();
    }

    public async Task<IResult> ToggleStatusAsync(string userId, ToggleUserStatusRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(UserRoutes.ToggleStatus(userId), request);
        return await response.ToResult();
    }
}
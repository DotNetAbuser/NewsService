using Shared.Contracts;

namespace Application.IRepositories;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(Guid userId);
    Task<UserEntity?> GetByIdWithRoleAsync(Guid userId);
    Task<UserEntity?> GetByUsernameWithRoleAsync(string username);
    Task<PaginatedData<UserEntity>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);

    Task CreateAsync(UserEntity entity);
    Task UpdateAsync(UserEntity entity);

    Task<bool> IsExistByUsername(string username);
    Task<bool> IsExistByEmail(string email);
    Task<bool> IsExistByPhone(string phone);
    Task<bool> IsExistForUpdateByEmail(Guid userId, string email);
    Task<bool> IsExistForUpdateByPhone(Guid userId, string phone);
}
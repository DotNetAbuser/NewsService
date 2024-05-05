using Shared.Contracts.Requests.Identity;

namespace Shared.IServices;

public interface IAccountService
{
    Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request);
    Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request);
}
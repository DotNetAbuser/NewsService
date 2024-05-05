namespace Client.Infrastructure.Managers;

public interface IAccountManager
{
    Task<IResult> UpdateProfileAsync(string userId, UpdateProfileRequest request);
    Task<IResult> ChangePasswordAsync(string userId, ChangePasswordRequest request);
}

public class AccountManager(
    IHttpClientFactory _factory)
    : IAccountManager
{
    public async Task<IResult> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(AccountRoutes.UpdateProfile(userId), request);
        return await response.ToResult();
    }

    public async Task<IResult> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(AccountRoutes.ChangePassword(userId), request);
        return await response.ToResult();
    }
}
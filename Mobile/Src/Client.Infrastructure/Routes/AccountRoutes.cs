namespace Client.Infrastructure.Routes;

public static class AccountRoutes
{
    private const string baseUrl = "api/identity/account";
    
    public static string UpdateProfile(string userId) =>
        baseUrl + $"/{userId}/update-profile";

    public static string ChangePassword(string userId) =>
        baseUrl + $"/{userId}/change-password";
}
namespace Client.Infrastructure.Routes;

public static class TokenRoutes
{
    private const string baseUrl = "api/identity/token";
    
    public static string SignIn = baseUrl;
    public static string RefreshToken = baseUrl + "/refresh-token";
}
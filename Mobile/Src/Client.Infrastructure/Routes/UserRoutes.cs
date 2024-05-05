namespace Client.Infrastructure.Routes;

public static class UserRoutes
{
    private const string baseUrl = "api/identity/user";
    
    public static string GetPaginatedUser(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder) =>
        baseUrl +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}" +
            $"&sortColumn={sortColumn}" +
            $"&sortOrder={sortOrder}";

    public static string GetById(string userId) =>
        baseUrl + $"/{userId}";

    public static string SignUp = baseUrl;

    public static string GetRolesById(string userId) =>
        baseUrl + $"/{userId}/role";

    public static string UpdateRoles(string userId) =>
        baseUrl + $"/{userId}/role";

    public static string ToggleStatus(string userId) =>
        baseUrl + $"/{userId}/toggle-status";
}
namespace Client.Infrastructure.Routes;

public static class NewsRoutes
{
    private const string baseUrl = "api/news"; 
    
    public static string GetPaginatedNews(int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder) =>
        baseUrl +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}" +
            $"&sortColumn={sortColumn}" +
            $"&sortOrder={sortOrder}";

    public static string? GetPaginatedViewsNewsByUserId(
        string userId,
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder) =>
        baseUrl + $"/{userId}/views" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}" +
            $"&sortColumn={sortColumn}" +
            $"&sortOrder={sortOrder}";

    public static string? GetPaginatedLikesNewsByUserId(
        string userId,
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder) =>
        baseUrl + $"/{userId}/likes" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}" +
            $"&sortColumn={sortColumn}" +
            $"&sortOrder={sortOrder}";

    public static string? GetPaginateBookMarksNewsByUserId(
        string userId,
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder) =>
        baseUrl + $"/{userId}/bookmarks" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}" +
            $"&sortColumn={sortColumn}" +
            $"&sortOrder={sortOrder}";

    public static string GetById(string newsId) =>
        baseUrl + $"/{newsId}";

    public static string Create = baseUrl;
    
    public static string Update(string newsId) =>
        baseUrl + $"/{newsId}";
    public static string Delete(string newsId) =>
        baseUrl + $"/{newsId}";

    public static string GetPaginatedNewsByCategoryId(
        int categoryId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder) =>
        baseUrl + $"/{categoryId}/category" +
        $"?pageNumber={pageNumber}" +
        $"&pageSize={pageSize}" +
        $"&searchTerms={searchTerms}" +
        $"&sortColumn={sortColumn}" +
        $"&sortOrder={sortOrder}";


    public static string GetPaginatedNewsByAuthorId(
        string userId,
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder) =>
        baseUrl + $"/{userId}/by-author" +
            $"?pageNumber={pageNumber}" +
            $"&pageSize={pageSize}" +
            $"&searchTerms={searchTerms}" +
            $"&sortColumn={sortColumn}" +
            $"&sortOrder={sortOrder}";
}
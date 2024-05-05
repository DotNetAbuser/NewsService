namespace Client.Infrastructure.Routes;

public static class CommentRoutes
{
    private const string baseUrl = "api/news"; 
    
    public static string GetPaginatedCommentsById(
        string newsId,
        int pageNumber, int pageSize,
        string? sortOrder) =>
        baseUrl + $"/{newsId}/comment" +
        $"?pageNumber={pageNumber}" +
        $"&pageSize={pageSize}" + 
        $"$sortOrder={sortOrder}";

    public static string CommentTheNews(string newsId) =>
        baseUrl + $"/{newsId}/comment";

    public static string UpdateCommentTheNews(string commentId) =>
        baseUrl + $"/comment/{commentId}";

    public static string RemoveCommentFromNews(string commentId) =>
        baseUrl + $"/comment/{commentId}";
}
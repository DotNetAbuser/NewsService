namespace Client.Infrastructure.Routes;

public static class LikeRoutes
{
    private const string baseUrl = "api/news"; 
    
    public static string LikeTheNews(string newsId) =>
        baseUrl + $"/{newsId}/like";
    
    public static string RemoveLikeFromNews(string newsId) =>
        baseUrl + $"/{newsId}/like";
}
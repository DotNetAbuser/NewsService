namespace Client.Infrastructure.Routes;

public static class BookMarkRoutes
{
    private const string baseUrl = "api/news"; 
    
    public static string BookMarkTheNews(string newsId) =>
        baseUrl + $"/{newsId}/bookmark";
    
    public static string RemoveNewsFromBookMark(string newsId) =>
        baseUrl + $"/{newsId}/bookmark";
}
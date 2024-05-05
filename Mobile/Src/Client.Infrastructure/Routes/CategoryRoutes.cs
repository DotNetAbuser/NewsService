namespace Client.Infrastructure.Routes;

public class CategoryRoutes
{
    private const string baseUrl = "api/news/category";

    public static string GetAll = baseUrl;

    public static string GetById(string categoryId) =>
        baseUrl + $"/{categoryId}";
    
    public static string Create = baseUrl;
    
    public static string Update(string categoryId) =>
        baseUrl + $"/{categoryId}";
    
    public static string Delete(string categoryId) =>
        baseUrl + $"/{categoryId}";
}
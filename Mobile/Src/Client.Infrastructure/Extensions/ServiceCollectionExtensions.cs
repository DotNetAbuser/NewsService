namespace Client.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IAlertService, AlertService>()
            .AddTransient<INavigationService, NavigationService>();
    }
    
    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        return services
            .AddTransient<IAccountManager, AccountManager>()
            .AddTransient<IBookMarkManager, BookMarkManager>()
            .AddTransient<ICategoryManager, CategoryManager>()
            .AddTransient<ICommentManager, CommentManager>()
            .AddTransient<ILikeManager, LikeManager>()
            .AddTransient<INewsManager, NewsManager>()
            .AddTransient<ITokenManager, TokenManager>()
            .AddTransient<IUserManager, UserManager>();
    }
}
using Application.IServices;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHelpers(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IPasswordHasher, PasswordHasher>()
            .AddTransient<IUploadFile, UploadFile>();
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IBookMarkRepository, BookMarkRepository>()
            .AddTransient<ICategoryRepository, CategoryRepository>()
            .AddTransient<ICommentRepository, CommentRepository>()
            .AddTransient<ILikeRepository, LikeRepository>()
            .AddTransient<INewsRepository, NewsRepository>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<ISessionRepository, SessionRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IViewRepository, ViewRepository>();
    }

    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IAccountService, AccountService>()
            .AddTransient<IBookMarkService, BookMarkService>()
            .AddTransient<ICategoryService, CategoryService>()
            .AddTransient<ICommentService, CommentService>()
            .AddTransient<ILikeService, LikeService>()
            .AddTransient<INewsService, NewsService>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<IUserService, UserService>();
    }
}
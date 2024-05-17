namespace Client.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddViewModels(this IServiceCollection services)
    {
        services
            .AddTransient<SignUpVM>()
            .AddTransient<SignInVM>()
            .AddTransient<StartUpVM>()
            .AddTransient<HomeVM>()
            .AddTransient<ProfileVM>()
            .AddTransient<NewsDetailsVM>()
            .AddTransient<NewsListVM>()
            .AddTransient<PublishNewsVM>()
            .AddTransient<MyPublishedNewsVM>()
            .AddTransient<ModerateNewsVM>();
    }
    
    internal static void AddViews(this IServiceCollection services)
    {
        services
            .AddTransient<SignUpView>()
            .AddTransient<SignInView>()
            .AddTransient<StartUpView>()
            .AddTransient<HomeView>()
            .AddTransient<ProfileView>()
            .AddTransient<NewsDetailsView>()
            .AddTransient<NewsListView>()
            .AddTransient<PublishNewsView>()
            .AddTransient<MyPublishedNewsView>()
            .AddTransient<ModerateNewsView>();
    }
    
    internal static void AddHttpClientFactory(this IServiceCollection services)
    {
        services
            .AddTransient<AuthorizationHeaderHandler>()
            .AddHttpClient(ApplicationConstants.BaseClient)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(ApplicationConstants.BaseAddress))
            .AddHttpMessageHandler<AuthorizationHeaderHandler>();
    }
}
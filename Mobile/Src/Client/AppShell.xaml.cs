namespace Client;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        AddRoutes();
    }

    private static void AddRoutes()
    {
        Routing.RegisterRoute(nameof(SignInView),
            typeof(SignInView));
        Routing.RegisterRoute(nameof(SignUpView),
            typeof(SignUpView));
        Routing.RegisterRoute(nameof(StartUpView),
            typeof(StartUpView));
        Routing.RegisterRoute(nameof(HomeView),
            typeof(HomeView));
        Routing.RegisterRoute(nameof(ProfileView),
            typeof(ProfileView));
        Routing.RegisterRoute(nameof(NewsDetailsView),
            typeof(NewsDetailsView));
        Routing.RegisterRoute(nameof(NewsListView),
            typeof(NewsListView));
        Routing.RegisterRoute(nameof(PublishNewsView),
            typeof(PublishNewsView));
        Routing.RegisterRoute(nameof(MyPublishedNewsView),
            typeof(MyPublishedNewsView));
    }
}
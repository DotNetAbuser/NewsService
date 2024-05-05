namespace Client.Infrastructure.Services;

public interface INavigationService
{
    Task NavigateToAsync(string route, IDictionary<string, object> parameters = null);
    Task NavigateBackAsync();
}

public class NavigationService(
    )
    : INavigationService
{
    public Task NavigateToAsync(string route, IDictionary<string, object> parameters = null)
    {
        return parameters != null
            ? Shell.Current.GoToAsync(route, true, parameters) 
            : Shell.Current.GoToAsync(route, true);
    }

    public async Task NavigateBackAsync() =>
        await Shell.Current.GoToAsync("..", true);
}
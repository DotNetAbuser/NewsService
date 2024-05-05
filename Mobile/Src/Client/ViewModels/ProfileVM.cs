namespace Client.ViewModels;

public partial class ProfileVM(
    IAlertService _alertService, 
    INavigationService _navigationService,
    ITokenManager _tokenManager,
    IUserManager _userManager) 
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        await RefreshDataAsync();
    }

    private async Task LoadDataUserAsync()
    {
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _userManager.GetByIdAsync(userId);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }

        ProfilePictureUrl = result.Data.ProfilePictureUrl;
        LastName = result.Data.LastName;
        FirstName = result.Data.FirstName;
        MiddleName = result.Data.MiddleName;
        Username = result.Data.Username;
        Email = result.Data.Email;
        Phone = result.Data.Phone;
        IsActive = result.Data.IsActive;
        Created = result.Data.Created;
    }

    [ObservableProperty] private string profilePictureUrl = string.Empty;
    [ObservableProperty] private string lastName = string.Empty;
    [ObservableProperty] private string firstName = string.Empty;
    [ObservableProperty] private string? middleName = string.Empty;
    [ObservableProperty] private string username= string.Empty;
    [ObservableProperty] private string email = string.Empty;
    [ObservableProperty] private string phone = string.Empty;
    [ObservableProperty] private bool isActive;
    [ObservableProperty] private DateTime created;

    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {
            await LoadDataUserAsync();
        }
        catch (Exception ex)
        {
            await _alertService.ShowAlertAsync(AlertType.Exception, ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private Task GoToNewsListViewByViewsAsync() =>
        _navigationService.NavigateToAsync(nameof(NewsListView), new Dictionary<string, object>
        {
            { "IsMyViews", true }
        });
    
    [RelayCommand]
    private Task GoToNewsListViewByLikesAsync() =>
        _navigationService.NavigateToAsync(nameof(NewsListView), new Dictionary<string, object>
        {
            { "IsMyLikes", true }
        });
    
    [RelayCommand]
    private Task GoToNewsListViewByBookMarksAsync() =>
        _navigationService.NavigateToAsync(nameof(NewsListView), new Dictionary<string, object>
        {
            { "IsMyBookMarks", true }
        });
    
    [RelayCommand]
    private async Task SignOutAsync()
    {
        await _tokenManager.SignOutAsync();
        await _navigationService.NavigateToAsync($"//{nameof(StartUpView)}");
    }
}
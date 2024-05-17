using Client.Infrastructure.Enums;

namespace Client.ViewModels;

public partial class SignInVM(
    IAlertService _alertService,
    INavigationService _navigationService,
    ITokenManager _tokenManager) 
    : BaseVM(_alertService, _navigationService)
{
    [ObservableProperty] private string username = string.Empty;
    [ObservableProperty] private string password = string.Empty;

    [ObservableProperty] private bool isUsernameValid;
    [ObservableProperty] private bool isPasswordValid;
    
    [ObservableProperty] private bool isPasswordNotVisible = true;

    [RelayCommand]
    private async Task ChangeIsPasswordAsync() =>
        IsPasswordNotVisible = !IsPasswordNotVisible;

    [RelayCommand]
    private async Task SignInAsync()
    {
        try
        {
            IsBusy = true;

            var request = new TokenRequest(
                Username: Username,
                Password: Password);
            var result = await _tokenManager.SignInAsync(request);
            if (!result.Succeeded)
            {
                foreach (var message in result.Messages)
                    await _alertService.ShowAlertAsync(AlertType.Error, message);
                return;
            }
            var token = await _tokenManager.GetJwtAsync();
            var role = await _tokenManager.GetUserRole(token);
            switch (role)
            {
                case "Guest":
                    await _navigationService.NavigateToAsync($"//HomeGuest");
                    break;
                case "Journalist":
                    await _navigationService.NavigateToAsync($"//HomeJournalist");
                    break;
                case "Redactor":
                    await _navigationService.NavigateToAsync($"//HomeRedactor");
                    break;
                case "Admin":
                    await _navigationService.NavigateToAsync($"//HomeAdmin");
                    break;
                default:
                    await _navigationService.NavigateToAsync($"//{nameof(SignInView)}");
                    break;
            }
            Username = string.Empty;
            Password = string.Empty;
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
    private async Task GoToSignUpViewAsync() =>
        await _navigationService.NavigateToAsync(nameof(SignUpView));
}
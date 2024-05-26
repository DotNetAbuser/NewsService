namespace Client.ViewModels;

public class StartUpVM(
    IAlertService _alertService,
    INavigationService _navigationService,
    ITokenManager _tokenManager) 
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        await CheckAuthStateAsync();
    }

    private async Task CheckAuthStateAsync()
    {
        try
        {
            IsBusy = true;
            var token = await _tokenManager.GetJwtAsync();
            if (string.IsNullOrWhiteSpace(token))
            {
                await _navigationService.NavigateToAsync($"//{nameof(SignInView)}");
                return;
            }
            var role = await _tokenManager.GetUserRole(token);
            switch (role)
            {
                case "Guest":
                    await _navigationService.NavigateToAsync($"//HomeGuest");
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
}
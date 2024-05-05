namespace Client.ViewModels.Base;

public partial class BaseVM(
    IAlertService _alertService,
    INavigationService _navigationService)
    : ObservableObject
{
    [ObservableProperty] protected bool isBusy;

    [RelayCommand]
    protected virtual async Task DisappearingView()
    {
        // base logic
    }
    
    [RelayCommand]
    protected virtual async Task AppearingView()
    {
        // base logic check INTERNET
    }
}
namespace Client.ViewModels;

public partial class ModerateNewsVM(
    IAlertService _alertService,
    INavigationService _navigationService,
    INewsManager _newsManager) 
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        await RefreshDataAsync();
    }

    private async Task LoadNewsDataAsync()
    {
        var result = await _newsManager.GetPaginatedNewsNotPublishedAsync(
            pageNumber, pageSize, searchTerms, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }

        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
    }

    public ObservableCollection<NewsResponse> NewsList { get; } = [];

    private int pageNumber = 1;
    private int pageSize = 5;
    private int totalCount;
    
    [ObservableProperty] private string searchTerms = string.Empty;

    [ObservableProperty] private bool isFooterLoading;
    [ObservableProperty] private bool isCanGetNextData;

    [RelayCommand]
    private async Task GoToNewsDetailsViewAsync(string newsId) =>
        await _navigationService.NavigateToAsync(nameof(NewsDetailsView), new Dictionary<string, object>
        {
            { "NewsId" , newsId }
        });
    
    [RelayCommand]
    private async Task AcceptNewsAsync(string newsId)
    {
        try
        {
            var request = new AcceptOrDeclineNewsRequest(
                true);
            var result = await _newsManager.AcceptOrDeclineNewsAsync(newsId, request);
            if (!result.Succeeded)
            {
                foreach (var message in result.Messages)
                    await _alertService.ShowAlertAsync(AlertType.Error, message);
                return;
            }
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Success, message);
            IsBusy = true;  
        }
        catch (Exception ex)
        {
            await _alertService.ShowAlertAsync(AlertType.Exception, ex.Message);
        }
    }

    [RelayCommand]
    private async Task DeclineNewsAsync(string newsId)
    {
        try
        {
            var request = new AcceptOrDeclineNewsRequest(
                false);
            var result = await _newsManager.AcceptOrDeclineNewsAsync(newsId, request);
            if (!result.Succeeded)
            {
                foreach (var message in result.Messages)
                    await _alertService.ShowAlertAsync(AlertType.Error, message);
                return;
            }
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Success, message);
            IsBusy = true;  
        }
        catch (Exception ex)
        {
            await _alertService.ShowAlertAsync(AlertType.Exception, ex.Message);
        }
    }
    
    [RelayCommand]
    private async Task SearchAsync() =>
        IsBusy = true;
    
    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {
            pageNumber = 1;
            NewsList.Clear();
            await LoadNewsDataAsync();
            IsCanGetNextData = NewsList.Count < totalCount;
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
    private async Task GetNextDataAsync()
    {
        try
        {
            IsFooterLoading = true;
            pageNumber += 1;
            await LoadNewsDataAsync();
            IsCanGetNextData = NewsList.Count < totalCount;
        }
        catch (Exception ex)
        {
            await _alertService.ShowAlertAsync(AlertType.Exception, ex.Message);
        }
        finally
        {
            IsFooterLoading = false;
        }
    }
}
namespace Client.ViewModels;

public partial class MyPublishedNewsVM(
    IAlertService _alertService,
    INavigationService _navigationService,
    INewsManager _newsManager,
    ITokenManager _tokenManager)
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        await RefreshDataAsync();
    }

    private async Task LoadDataNewsAsync()
    {
        NewsList.Clear();
        pageNumber = 1;
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedNewsByAuthorIdAsync(
            userId,
            pageNumber, pageSize,
            SearchTerms, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }
        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
        IsCanGetNextData = NewsList.Count < totalCount;
    }

    private int pageNumber = 1;
    private int pageSize = 3;
    private int totalCount;

    public ObservableCollection<NewsResponse> NewsList { get; } = [];

    [ObservableProperty] private string searchTerms = string.Empty;

    [ObservableProperty] private bool isCanGetNextData;
    [ObservableProperty] private bool isFooterLoading;

    [RelayCommand]
    private async Task DeleteNewsAsync(string newsId)
    {
        try
        {
            var result = await _newsManager.DeleteAsync(newsId);
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
    private async Task GoToNewsDetailsViewAsync(string newsId) =>
        await _navigationService.NavigateToAsync(nameof(NewsDetailsView), new Dictionary<string, object>
        {
            { "NewsId" , newsId }
        });

    [RelayCommand]
    private async Task GoToPublishNewsViewAsync() =>
        await _navigationService.NavigateToAsync(nameof(PublishNewsView));
    
    [RelayCommand]
    private void SearchAsync() =>
        IsBusy = true;
        
    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {
            await LoadDataNewsAsync();
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
    private async Task GetNextDataNewsAsync()
    {
        try
        {
            try
            {
                IsFooterLoading = true;
                pageNumber += 1;
                var result = await _newsManager.GetPaginatedNewsAsync(
                    pageNumber, pageSize,
                    null, null, null);
                if (!result.Succeeded)
                {
                    foreach (var message in result.Messages)
                        await _alertService.ShowAlertAsync(AlertType.Error, message);
                    return;
                }
                foreach (var news in result.Data.List)
                    NewsList.Add(news);
                totalCount = result.Data.TotalCount;
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
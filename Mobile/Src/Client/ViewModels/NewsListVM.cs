namespace Client.ViewModels;

[QueryProperty(nameof(SearchTerms), nameof(SearchTerms))]
[QueryProperty(nameof(CategoryId), nameof(CategoryId))]
[QueryProperty(nameof(CategoryName), nameof(CategoryName))]
[QueryProperty(nameof(IsMyViews), nameof(IsMyViews))]
[QueryProperty(nameof(IsMyLikes), nameof(IsMyLikes))]
[QueryProperty(nameof(IsMyBookMarks), nameof(IsMyBookMarks))]
public partial class NewsListVM(
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

    private async Task LoadNewsDataBySearchTermsAsync()
    {
        PageTitle = "Результаты поиска...";
        var result = await _newsManager.GetPaginatedNewsAsync(
            pageNumber, pageSize,
            searchTerms, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }
        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
    }

    private async Task LoadNewsDataByCategoryAsync()
    {
        PageTitle = CategoryName;
        var result = await _newsManager.GetPaginatedNewsByCategoryAsync(
            CategoryId,
            pageNumber, pageSize,
            null, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }
        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
    }
    
    private async Task LoadViewsNewsDataAsync()
    {
        PageTitle = "Просмотренные";
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedViewsNewsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            null, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }
        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
    }
    
    private async Task LoadLikesNewsDataAsync()
    {
        PageTitle = "Понравившийся";
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedLikesNewsByUserIdAsync(
            userId,
            pageNumber, pageSize, 
            null, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }
        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
    }

    private async Task LoadBookMarksNewsDataAsync()
    {
        PageTitle = "Закладки";
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedBookMarksNewsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            null, null, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }
        foreach (var news in result.Data.List)
            NewsList.Add(news);
        totalCount = result.Data.TotalCount;
    }
    
    private int pageNumber = 1;
    private int pageSize = 5;
    private int totalCount;
    
    public ObservableCollection<NewsResponse> NewsList { get; } = [];

    [ObservableProperty] private string pageTitle = string.Empty;
    
    [ObservableProperty] private string searchTerms = string.Empty;
    
    [ObservableProperty] private int categoryId = 0;
    [ObservableProperty] private string categoryName = string.Empty;

    [ObservableProperty] private bool isMyViews;
    [ObservableProperty] private bool isMyLikes;
    [ObservableProperty] private bool isMyBookMarks;
    
    [ObservableProperty] private bool isFooterLoading;
    [ObservableProperty] private bool isCanGetNextData;

    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {      
            pageNumber = 1;
            NewsList.Clear();
            if (!string.IsNullOrWhiteSpace(SearchTerms))
                await LoadNewsDataBySearchTermsAsync();
            else if (CategoryId != 0)
                await LoadNewsDataByCategoryAsync();
            else if (IsMyViews)
                await LoadViewsNewsDataAsync();
            else if (IsMyLikes)
                await LoadLikesNewsDataAsync();
            else if (IsMyBookMarks)
                await LoadBookMarksNewsDataAsync();
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
    private async Task GoToNewsDetailsView(string newsId) =>
        await _navigationService.NavigateToAsync(nameof(NewsDetailsView), new Dictionary<string, object>
        {
            { "NewsId" , newsId }
        });

    [RelayCommand]
    private async Task GetNextDataAsync()
    {
        try
        {
            IsFooterLoading = true;
            pageNumber += 1;
            
            if (!string.IsNullOrWhiteSpace(SearchTerms))
                await GetNextDataBySearchTermsAsync();
            else if (CategoryId != 0)
                await GetNextDataByCategoryIdAsync();
            else if (IsMyViews)
                await GetNextDataViewsByUserIdAsync();
            else if (IsMyLikes)
                await GetNextDataLikesByUserIdAsync();
            else if (IsMyBookMarks)
                await GetNextDataBookMarksByUserIdAsync();
            
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

    private async Task GetNextDataBookMarksByUserIdAsync()
    {
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedBookMarksNewsByUserIdAsync(
            userId, pageNumber, pageSize, null, null, null);
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

    private async Task GetNextDataLikesByUserIdAsync()
    {
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedLikesNewsByUserIdAsync(
            userId, pageNumber, pageSize, null, null, null);
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

    private async Task GetNextDataViewsByUserIdAsync()
    {
        var token = await _tokenManager.GetJwtAsync();
        var userId = await _tokenManager.GetUserIdAsync(token);
        var result = await _newsManager.GetPaginatedViewsNewsByUserIdAsync(
            userId, pageNumber, pageSize, null, null, null);
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

    private async Task GetNextDataBySearchTermsAsync()
    {
        var result = await _newsManager.GetPaginatedNewsAsync(
            pageNumber, pageSize, SearchTerms, null, null);
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
    
    private async Task GetNextDataByCategoryIdAsync()
    {
        var result = await _newsManager.GetPaginatedNewsByCategoryAsync(
            CategoryId, pageNumber, pageSize, null, null, null);
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
}
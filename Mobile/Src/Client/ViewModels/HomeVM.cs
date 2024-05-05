namespace Client.ViewModels;

public partial class HomeVM(
    IAlertService _alertService,
    INavigationService _navigationService,
    ICategoryManager _categoryManager,
    INewsManager _newsManager) 
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        if (isFirstRender)
        {
            isFirstRender = false;
            await RefreshDataAsync();
        }
    }

    private async Task LoadCategoriesAsync()
    {
        var result = await _categoryManager.GetAllAsync();
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }

        CategoryList = [..result.Data];
    }
    private async Task LoadPopularNewsAsync()
    {
        PopularNewsList.Clear();
        
        var result = await _newsManager.GetPaginatedNewsAsync(1, 5,null,"likes",null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }

        foreach (var news in result.Data.List)
            PopularNewsList.Add(news);
    }
    private async Task LoadAllNewsAsync()
    {
        AllNewsList.Clear();

        IsCanGetNextData = true;
        pageNumber = 1;
        
        var result = await _newsManager.GetPaginatedNewsAsync(pageNumber, pageSize,
            null,null,null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }

        foreach (var news in result.Data.List)
            AllNewsList.Add(news);
        totalCount = result.Data.TotalCount;
        IsCanGetNextData = AllNewsList.Count < totalCount;
    }

    private bool isFirstRender = true;
    
    private int pageNumber = 1;
    private int pageSize = 3;
    private int totalCount;
    
    public ObservableCollection<NewsResponse> PopularNewsList { get; } = [];
    public ObservableCollection<NewsResponse> AllNewsList { get; } = [];
    [ObservableProperty] private string searchTerms = string.Empty;
    
    [ObservableProperty] private List<CategoryResponse> categoryList = [];
    [ObservableProperty] private bool isFooterLoading;
    [ObservableProperty] private bool isCanGetNextData;
    
    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {
            await LoadCategoriesAsync();
            await LoadPopularNewsAsync();
            await LoadAllNewsAsync();
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
    private async Task SearchAsync() =>
        await _navigationService.NavigateToAsync(nameof(NewsListView), new Dictionary<string, object>
        {
            { "SearchTerms", SearchTerms }
        });
    
    [RelayCommand]
    private async Task GetNextDataAsync()
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
                AllNewsList.Add(news);
            totalCount = result.Data.TotalCount;
            IsCanGetNextData = AllNewsList.Count < totalCount;
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

    [RelayCommand]
    private async Task GoToNewsDetailsViewAsync(string newsId) =>
        await _navigationService.NavigateToAsync(nameof(NewsDetailsView), new Dictionary<string, object>
        {
            { "NewsId" , newsId }
        });

    [RelayCommand]
    private async Task GoToNewsByCategoryAsync(CategoryResponse model) =>
        await _navigationService.NavigateToAsync(nameof(NewsListView), new Dictionary<string, object>
        {
            { "CategoryId", model.ID },
            { "CategoryName", model.Name }
        });

}
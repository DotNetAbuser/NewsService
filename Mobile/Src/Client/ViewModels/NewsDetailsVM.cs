namespace Client.ViewModels;

[QueryProperty(nameof(NewsId), nameof(NewsId))]
public partial class NewsDetailsVM(
    IAlertService _alertService, 
    INavigationService _navigationService,
    INewsManager _newsManager,
    ICommentManager _commentManager,
    IBookMarkManager _bookMarkManager,
    ILikeManager _likeManager,
    ITokenManager _tokenManager) 
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        await RefreshDataAsync();
    }

    private async Task LoadNewsDataAsync()
    {
        var result = await _newsManager.GetByIdAsync(NewsId);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }
        Category = result.Data.Category;
        AuthorProfilePictureUrl = result.Data.AuthorProfilePictureUrl;
        AuthorLastName = result.Data.AuthorLastName;
        AuthorFirstName = result.Data.AuthorFirstName;
        AuthorMiddleName = result.Data.AuthorMiddleName;
        ImageTitleUrl = result.Data.ImageTitleUrl;
        Title = result.Data.Title;
        Content = result.Data.Content;
        ViewsCount = result.Data.ViewsCount;
        LikesCount = result.Data.LikesCount;
        CommentsCount = result.Data.CommentsCount;
        IsViewed = result.Data.IsViewed;
        IsLiked = result.Data.IsLiked;
        IsBookMarked = result.Data.IsBookMarked;
        Created = result.Data.Created;
    }

    private async Task LoadCommentsDataAsync()
    {
        pageNumber = 1;
        var result = await _commentManager
            .GetPaginatedCommentsByNewsIdAsync(NewsId, pageNumber, pageSize, null);
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            return;
        }
        CommentsList.Clear();
        foreach (var comment in result.Data.List)
            CommentsList.Add(comment);
        TotalCount = result.Data.TotalCount;
    }

    private int pageNumber = 1;
    private int pageSize = 5;

    public ObservableCollection<CommentResponse> CommentsList { get; } = [];
    
    [ObservableProperty] private string newsId = string.Empty;
    [ObservableProperty] private string category = string.Empty;
    [ObservableProperty] private string authorProfilePictureUrl = string.Empty;
    [ObservableProperty] private string authorLastName = string.Empty;
    [ObservableProperty] private string authorFirstName = string.Empty;
    [ObservableProperty] private string authorMiddleName = string.Empty;
    [ObservableProperty] private string imageTitleUrl = string.Empty;
    [ObservableProperty] private string title = string.Empty;
    [ObservableProperty] private string content = string.Empty;
    [ObservableProperty] private int viewsCount;
    [ObservableProperty] private int likesCount;
    [ObservableProperty] private int commentsCount;
    [ObservableProperty] private bool isViewed;
    [ObservableProperty] private bool isLiked;
    [ObservableProperty] private bool isBookMarked;
    [ObservableProperty] private DateTime created;
 
    [ObservableProperty] private int totalCount;
    [ObservableProperty] private bool isCanGetNextCommentsData = true;
    
    [RelayCommand]
    private async Task RefreshDataAsync()
    {
        try
        {
            await LoadNewsDataAsync();
            await LoadCommentsDataAsync();
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
    private async Task LikeChangeStateAsync()
    {
        try
        {
            if (!IsLiked)
            {
                var token = await _tokenManager.GetJwtAsync();
                var userId = await _tokenManager.GetUserIdAsync(token);
                var request = new CreateLikeRequest(userId);
                var result = await _likeManager.CreateAsync(newsId, request);
                if (!result.Succeeded)
                {
                    foreach (var message in result.Messages)
                        await _alertService.ShowAlertAsync(AlertType.Error, message);
                    return;
                }
                LikesCount += 1;
                IsLiked = true; 
            }
            else
            {
                var result = await _likeManager.DeleteAsync(newsId);
                if (!result.Succeeded)
                {
                    foreach (var message in result.Messages)
                        await _alertService.ShowAlertAsync(AlertType.Error, message);
                    return;
                }

                LikesCount -= 1;
                IsLiked = false; 
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
    
    [RelayCommand]
    private async Task BookMarkChangeStateAsync()
    {
        try
        {
            if (!IsBookMarked)
            {
                var token = await _tokenManager.GetJwtAsync();
                var userId = await _tokenManager.GetUserIdAsync(token);
                var request = new CreateBookMarkRequest(userId);
                var result = await _bookMarkManager.CreateAsync(newsId, request);
                if (!result.Succeeded)
                {
                    foreach (var message in result.Messages)
                        await _alertService.ShowAlertAsync(AlertType.Error, message);
                    return;
                }
                IsBookMarked = true; 
            }
            else
            {
                var result = await _bookMarkManager.DeleteAsync(newsId);
                if (!result.Succeeded)
                {
                    foreach (var message in result.Messages)
                        await _alertService.ShowAlertAsync(AlertType.Error, message);
                    return;
                }
                IsBookMarked = false; 
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

    [RelayCommand]
    private async Task GetNextDataCommentsAsync()
    {
        
    }

}
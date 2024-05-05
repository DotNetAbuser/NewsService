using Shared.Enums;

namespace Client.ViewModels;

public partial class PublishNewsVM(
    IAlertService _alertService,
    INavigationService _navigationService,
    ICategoryManager _categoryManager,
    INewsManager _newsManager)
    : BaseVM(_alertService, _navigationService)
{
    protected override async Task AppearingView()
    {
        await base.AppearingView();
        await LoadDataAsync();
    }

    private async Task LoadDataCategoriesAsync()
    {
        var result = await _categoryManager.GetAllAsync();
        if (!result.Succeeded)
        {
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Error, message);
            await _navigationService.NavigateBackAsync();
            return;
        }

        CategoryList = [..result.Data];
    }

    private UploadRequest? imageTitleUploadRequest;

    [ObservableProperty] private string imageName = string.Empty;
    [ObservableProperty] private string imageFilePath = string.Empty;
    [ObservableProperty] private string title = string.Empty;
    [ObservableProperty] private string content = string.Empty;

    [ObservableProperty] private IEnumerable<CategoryResponse> categoryList = [];
    [ObservableProperty] private CategoryResponse selectedCategory;


    [RelayCommand]
    private async Task LoadDataAsync()
    {
        try
        {
            IsBusy = true;
            await LoadDataCategoriesAsync();
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
    private async Task ImportImageNewsFilePathAsync()
    {
        try
        {
            IsBusy = true;
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Выбор картинки для новости",
                FileTypes = FilePickerFileType.Jpeg
            });
            if (result == null)
                return;
            ImageName = result.FileName;
            ImageFilePath = result.FullPath;
            imageTitleUploadRequest = new UploadRequest
            {
                UploadType = UploadType.NewsTitlePicture,
                FileName = result.FileName,
                Extension = Path.GetExtension(result.FileName),
                Data = await File.ReadAllBytesAsync(result.FullPath)
            };
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
    private async Task ClearImageNewsFilePathAsync()
    {
        ImageName = string.Empty;
        ImageFilePath = string.Empty;
        imageTitleUploadRequest = null;
    }

[RelayCommand]
    private async Task PublishNewsAsync()
    {
        try
        {
            IsBusy = true;
            var request = new CreateNewsRequest(
                CategoryId: SelectedCategory.ID,
                ImageTitleUploadRequest: imageTitleUploadRequest,
                Title: Title,
                Content: Content);
            var result = await _newsManager.CreateAsync(request);
            if (!result.Succeeded)
            {
                foreach (var message in result.Messages)
                    await _alertService.ShowAlertAsync(AlertType.Error, message);
                return;
            }
            foreach (var message in result.Messages)
                await _alertService.ShowAlertAsync(AlertType.Success, message);
            await _navigationService.NavigateBackAsync();
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
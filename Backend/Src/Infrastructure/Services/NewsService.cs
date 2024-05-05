using Application.IServices;

namespace Infrastructure.Services;

public class NewsService(
    IHttpContextAccessor _httpContextAccessor,
    IUploadFile _uploadFile,
    IViewRepository _viewRepository,
    INewsRepository _newsRepository,
    IUserRepository _userRepository,
    ICategoryRepository _categoryRepository) 
    : INewsService
{
    public async Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsAsync(
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var (newsEntities, totalCount) = await _newsRepository.GetPaginatedNewsAsync(
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        var newsResponse = newsEntities
            .Select(newsEntity => new NewsResponse(
                ID: newsEntity.ID.ToString(),
                Category: newsEntity.Category.Name,
                AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
                AuthorLastName: newsEntity.User.LastName,
                AuthorFirstName: newsEntity.User.FirstName,
                AuthorMiddleName: newsEntity.User.MiddleName,
                ImageTitleUrl: newsEntity.ImageTitleUrl,
                Title: newsEntity.Title,
                Content: newsEntity.Content,
                ViewsCount: newsEntity.Views.Count,
                LikesCount: newsEntity.Likes.Count,
                CommentsCount: newsEntity.Comments.Count,
                IsViewed: newsEntity.Views.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsLiked: newsEntity.Likes.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsBookMarked: newsEntity.BookMarks.Any(x => 
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                Created: newsEntity.Created)).ToList();
        var paginatedNewsResponse = new PaginatedData<NewsResponse>(
            List: newsResponse, TotalCount: totalCount);
        return Result<PaginatedData<NewsResponse>>
            .Success(paginatedNewsResponse, "Новости успешно получены.");
    }

    public async Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsByCategoryIdAsync(
        int categoryId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var (newsEntities, totalCount) = await _newsRepository
            .GetPaginatedNewsByCategoryIdAsync(
            categoryId,
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        var newsResponse = newsEntities
            .Select(newsEntity => new NewsResponse(
                ID: newsEntity.ID.ToString(),
                Category: newsEntity.Category.Name,
                AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
                AuthorLastName: newsEntity.User.LastName,
                AuthorFirstName: newsEntity.User.FirstName,
                AuthorMiddleName: newsEntity.User.MiddleName,
                ImageTitleUrl: newsEntity.ImageTitleUrl,
                Title: newsEntity.Title,
                Content: newsEntity.Content,
                ViewsCount: newsEntity.Views.Count,
                LikesCount: newsEntity.Likes.Count,
                CommentsCount: newsEntity.Comments.Count,
                IsViewed: newsEntity.Views.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsLiked: newsEntity.Likes.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsBookMarked: newsEntity.BookMarks.Any(x => 
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                Created: newsEntity.Created)).ToList();
        var paginatedNewsResponse = new PaginatedData<NewsResponse>(
            List: newsResponse, TotalCount: totalCount);
        return Result<PaginatedData<NewsResponse>>
            .Success(paginatedNewsResponse, "Новости успешно получены.");
    }

    public async Task<Result<PaginatedData<NewsResponse>>> GetPaginatedViewsNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var (newsEntities, totalCount) = await _newsRepository
            .GetPaginatedViewsNewsByUserIdAsync(
                Guid.Parse(userId),
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder);
        var newsResponse = newsEntities
            .Select(newsEntity => new NewsResponse(
                ID: newsEntity.ID.ToString(),
                Category: newsEntity.Category.Name,
                AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
                AuthorLastName: newsEntity.User.LastName,
                AuthorFirstName: newsEntity.User.FirstName,
                AuthorMiddleName: newsEntity.User.MiddleName,
                ImageTitleUrl: newsEntity.ImageTitleUrl,
                Title: newsEntity.Title,
                Content: newsEntity.Content,
                ViewsCount: newsEntity.Views.Count,
                LikesCount: newsEntity.Likes.Count,
                CommentsCount: newsEntity.Comments.Count,
                IsViewed: newsEntity.Views.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsLiked: newsEntity.Likes.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsBookMarked: newsEntity.BookMarks.Any(x => 
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                Created: newsEntity.Created)).ToList();
        var paginatedNewsResponse = new PaginatedData<NewsResponse>(
            List: newsResponse, TotalCount: totalCount);
        return Result<PaginatedData<NewsResponse>>
            .Success(paginatedNewsResponse, "Новости успешно получены.");
    }

    public async Task<Result<PaginatedData<NewsResponse>>> GetPaginatedLikesNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var (newsEntities, totalCount) = await _newsRepository
            .GetPaginatedLikesNewsByUserIdAsync(
                Guid.Parse(userId),
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder);
        var newsResponse = newsEntities
            .Select(newsEntity => new NewsResponse(
                ID: newsEntity.ID.ToString(),
                Category: newsEntity.Category.Name,
                AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
                AuthorLastName: newsEntity.User.LastName,
                AuthorFirstName: newsEntity.User.FirstName,
                AuthorMiddleName: newsEntity.User.MiddleName,
                ImageTitleUrl: newsEntity.ImageTitleUrl,
                Title: newsEntity.Title,
                Content: newsEntity.Content,
                ViewsCount: newsEntity.Views.Count,
                LikesCount: newsEntity.Likes.Count,
                CommentsCount: newsEntity.Comments.Count,
                IsViewed: newsEntity.Views.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsLiked: newsEntity.Likes.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsBookMarked: newsEntity.BookMarks.Any(x => 
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                Created: newsEntity.Created)).ToList();
        var paginatedNewsResponse = new PaginatedData<NewsResponse>(
            List: newsResponse, TotalCount: totalCount);
        return Result<PaginatedData<NewsResponse>>
            .Success(paginatedNewsResponse, "Новости успешно получены.");
    }

    public async Task<Result<PaginatedData<NewsResponse>>> GetPaginatedBookMarksNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var (newsEntities, totalCount) = await _newsRepository
            .GetPaginatedBookMarksNewsByUserIdAsync(
                Guid.Parse(userId),
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder);
        var newsResponse = newsEntities
            .Select(newsEntity => new NewsResponse(
                ID: newsEntity.ID.ToString(),
                Category: newsEntity.Category.Name,
                AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
                AuthorLastName: newsEntity.User.LastName,
                AuthorFirstName: newsEntity.User.FirstName,
                AuthorMiddleName: newsEntity.User.MiddleName,
                ImageTitleUrl: newsEntity.ImageTitleUrl,
                Title: newsEntity.Title,
                Content: newsEntity.Content,
                ViewsCount: newsEntity.Views.Count,
                LikesCount: newsEntity.Likes.Count,
                CommentsCount: newsEntity.Comments.Count,
                IsViewed: newsEntity.Views.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsLiked: newsEntity.Likes.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsBookMarked: newsEntity.BookMarks.Any(x => 
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                Created: newsEntity.Created)).ToList();
        var paginatedNewsResponse = new PaginatedData<NewsResponse>(
            List: newsResponse, TotalCount: totalCount);
        return Result<PaginatedData<NewsResponse>>
            .Success(paginatedNewsResponse, "Новости успешно получены.");
    }

    public async Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsByAuthorId(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var (newsEntities, totalCount) = await _newsRepository
            .GetPaginatedNewsByAuthorIdAsync(
                Guid.Parse(userId),
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder);
        var newsResponse = newsEntities
            .Select(newsEntity => new NewsResponse(
                ID: newsEntity.ID.ToString(),
                Category: newsEntity.Category.Name,
                AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
                AuthorLastName: newsEntity.User.LastName,
                AuthorFirstName: newsEntity.User.FirstName,
                AuthorMiddleName: newsEntity.User.MiddleName,
                ImageTitleUrl: newsEntity.ImageTitleUrl,
                Title: newsEntity.Title,
                Content: newsEntity.Content,
                ViewsCount: newsEntity.Views.Count,
                LikesCount: newsEntity.Likes.Count,
                CommentsCount: newsEntity.Comments.Count,
                IsViewed: newsEntity.Views.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsLiked: newsEntity.Likes.Any(x =>
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                IsBookMarked: newsEntity.BookMarks.Any(x => 
                    x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
                Created: newsEntity.Created)).ToList();
        var paginatedNewsResponse = new PaginatedData<NewsResponse>(
            List: newsResponse, TotalCount: totalCount);
        return Result<PaginatedData<NewsResponse>>
            .Success(paginatedNewsResponse, "Новости успешно получены.");
    }

    public async Task<Result<NewsResponse>> GetByIdAsync(string newsId)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var newsEntity = await _newsRepository
            .GetByIdWithUserAndListsAsync(Guid.Parse(newsId));
        if (newsEntity == null)
        {
            return Result<NewsResponse>
                .Fail("Новость с данным идентификатором не найдена!");
        }
        var newsResponse = new NewsResponse(
            ID: newsEntity.ID.ToString(),
            Category: newsEntity.Category.Name,
            AuthorProfilePictureUrl: newsEntity.User.ProfilePictureUrl,
            AuthorLastName: newsEntity.User.LastName,
            AuthorFirstName: newsEntity.User.FirstName,
            AuthorMiddleName: newsEntity.User.MiddleName,
            ImageTitleUrl: newsEntity.ImageTitleUrl,
            Title: newsEntity.Title,
            Content: newsEntity.Content,
            ViewsCount: newsEntity.Views.Count,
            LikesCount: newsEntity.Likes.Count,
            CommentsCount: newsEntity.Comments.Count,
            IsViewed: newsEntity.Views.Any(x =>
                x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
            IsLiked: newsEntity.Likes.Any(x =>
                x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
            IsBookMarked: newsEntity.BookMarks.Any(x => 
                x.NewsId == newsEntity.ID && x.UserId == Guid.Parse(claims.GetLoggedInUserId<string>())),
            Created: newsEntity.Created);
        var currentUserId = claims.GetLoggedInUserId<string>();
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(currentUserId));
        if (userEntity == null)
        {
            return Result<NewsResponse>
                .Fail("Пользователь с данным идентификатором не найден!");
        }
        var isAlreadyViewed = await _viewRepository
            .IsExistByUserIdAndNewsIdAsync(userEntity.ID, newsEntity.ID);
        if (!isAlreadyViewed)
        {
            var viewEntity = new ViewEntity
            {
                UserId = userEntity.ID,
                NewsId = newsEntity.ID,
                Created = DateTime.UtcNow
            };
            await _viewRepository.CreateAsync(viewEntity);
        }
        
        return Result<NewsResponse>
            .Success(newsResponse, "Новость успешно получена!");
    }

    public async Task<Result> CreateAsync(CreateNewsRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var titleIsExist = await _newsRepository
            .IsExistByTitleAsync(request.Title);
        if (titleIsExist)
        {
            return Result<string>
                .Fail("Новость с таким же названием уже существует!");
        }

        var categoryEntity = await _categoryRepository
            .GetByIdAsync(request.CategoryId);
        if (categoryEntity == null)
        {
            return Result<string>
                .Fail("Категории не существует в системе!");
        }
        var newsEntity = new NewsEntity
        {
            UserId = Guid.Parse(currentUserId),
            CategoryId = request.CategoryId,
            Title = request.Title,
            Content = request.Content,
            Created = DateTime.UtcNow
        };
        if (request.ImageTitleUploadRequest != null)
            newsEntity.ImageTitleUrl = _uploadFile.Upload(request.ImageTitleUploadRequest);
        await _newsRepository.CreateAsync(newsEntity);
        return Result<string>
            .Success("Новость успешно опубликованна.");
    }

    public async Task<Result> UpdateAsync(string newsId, UpdateNewsRequest request)
    {
        var newsEntity = await _newsRepository
            .GetByIdAsync(Guid.Parse(newsId));
        if (newsEntity == null)
        {
            return Result<string>
                .Fail("Новость с данным идентификатором не существует!");
        }
        
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = newsEntity.UserId.ToString() == currentUserId;
        var currentUserRole = claims.GetLoggedInUserRole<string>();
        var isCurrentUserAdmin = currentUserRole == Role.Admin.ToString();
        if (!isCurrentUser && !isCurrentUserAdmin)
        {
            return Result<string>
                .Fail("Для изменения не своей новости нужно иметь роль Админа!");
        }

        var titleIsExistForUpdate = await _newsRepository
            .IsExistForUpdateByTitleAsync(Guid.Parse(newsId), request.Title);
        if (titleIsExistForUpdate)
        {
            return Result<string>
                .Fail("Новость с таким же названием уже существует!");
        }
        
        var categoryEntity = _categoryRepository
            .GetByIdAsync(request.CategoryId);
        if (categoryEntity == null)
        {
            return Result<string>
                .Fail("Категории не существует в системе!");
        }
        
        newsEntity.CategoryId = request.CategoryId;
        if (request.ImageTitleUploadRequest != null)
            newsEntity.ImageTitleUrl = _uploadFile.Upload(request.ImageTitleUploadRequest);
        newsEntity.Title = request.Title;
        newsEntity.Content = request.Content;
        await _newsRepository.UpdateAsync(newsEntity);
        return Result<string>
            .Success("Новость успешно изменена.");
    }

    public async Task<Result> DeleteAsync(string newsId)
    {
        var newsEntity = await _newsRepository
            .GetByIdAsync(Guid.Parse(newsId));
        if (newsEntity == null)
        {
            return Result<string>
                .Fail("Новость с данным идентификатором не существует!");
        }
        
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = newsEntity.UserId.ToString() == currentUserId;
        var currentUserRole = claims.GetLoggedInUserRole<string>();
        var isCurrentUserAdmin = currentUserRole == Role.Admin.ToString();
        if (!isCurrentUser && !isCurrentUserAdmin)
        {
            return Result<string>
                .Fail("Для удаления не своей новости нужно иметь роль Админа!");
        }

        await _newsRepository.DeleteAsync(newsEntity);
        return Result<string>
            .Success("Новость успешно удалена.");
    }
}
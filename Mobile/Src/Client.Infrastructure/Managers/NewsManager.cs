namespace Client.Infrastructure.Managers;

public interface INewsManager
{
    Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedNewsAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);

    Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedNewsByCategoryAsync(
        int categoryId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);
    Task<IResult<NewsResponse>> GetByIdAsync(string newsId);
    Task<IResult> CreateAsync(CreateNewsRequest request);
    Task<IResult> UpdateAsync(string newsId, UpdateNewsRequest request);
    Task<IResult> DeleteAsync(string newsId);
    Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedViewsNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder);
    Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedLikesNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize, 
        string searchTerms, string sortColumn, string sortOrder);
    Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedBookMarksNewsByUserIdAsync(
        string userId, 
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder);

    Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedNewsByAuthorIdAsync(
        string userId,
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder);
}

public class NewsManager(
    IHttpClientFactory _factory)
    : INewsManager
{
    public async Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedNewsAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetPaginatedNews(
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<NewsResponse>>();
    }

    public async Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedNewsByCategoryAsync(
        int categoryId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetPaginatedNewsByCategoryId(
                categoryId,
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<NewsResponse>>();
    }

    public async Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedViewsNewsByUserIdAsync(
        string userId, 
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetPaginatedViewsNewsByUserId(
                userId,
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<NewsResponse>>();
    }

    public async Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedLikesNewsByUserIdAsync(
        string userId, 
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetPaginatedLikesNewsByUserId(
                userId,
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<NewsResponse>>();
    }

    public async Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedBookMarksNewsByUserIdAsync(
        string userId, 
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetPaginateBookMarksNewsByUserId(
                userId,
                pageNumber, pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<NewsResponse>>();
    }

    public async Task<IResult<PaginatedData<NewsResponse>>> GetPaginatedNewsByAuthorIdAsync(string userId, int pageNumber, int pageSize, string searchTerms, string sortColumn,
        string sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetPaginatedNewsByAuthorId(
                userId,
                pageNumber , pageSize,
                searchTerms, sortColumn, sortOrder));
        return await response.ToResult<PaginatedData<NewsResponse>>();
    }

    public async Task<IResult<NewsResponse>> GetByIdAsync(string newsId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(NewsRoutes.GetById(newsId));
        return await response.ToResult<NewsResponse>();
    }

    public async Task<IResult> CreateAsync(CreateNewsRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PostAsJsonAsync(NewsRoutes.Create, request);
        return await response.ToResult();
    }

    public async Task<IResult> UpdateAsync(string newsId, UpdateNewsRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(NewsRoutes.Update(newsId), request);
        return await response.ToResult();
    }

    public async Task<IResult> DeleteAsync(string newsId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .DeleteAsync(NewsRoutes.Delete(newsId));
        return await response.ToResult();
    }
}
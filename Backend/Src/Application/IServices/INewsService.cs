namespace Application.IServices;

public interface INewsService
{
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsNotPublishedAsync(
        int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsAsync(
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder);
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsByCategoryIdAsync(
        int categoryId, 
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedViewsNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize, 
        string? searchTerms, string? sortColumn, string? sortOrder);
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedLikesNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize, 
        string? searchTerms, string? sortColumn, string? sortOrder);
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedBookMarksNewsByUserIdAsync(
        string userId,
        int pageNumber, int pageSize, 
        string? searchTerms, string? sortColumn, string? sortOrder);
    Task<Result<PaginatedData<NewsResponse>>> GetPaginatedNewsByAuthorId(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder);
    
    Task<Result<NewsResponse>> GetByIdAsync(string newsId);
    Task<Result> CreateAsync(CreateNewsRequest request);
    Task<Result> UpdateAsync(string newsId, UpdateNewsRequest request);
    Task<Result> DeleteAsync(string newsId);
    
    Task<Result> AcceptOrDeclineNewsRequestAsync(string newsId, AcceptOrDeclineNewsRequest request);
}
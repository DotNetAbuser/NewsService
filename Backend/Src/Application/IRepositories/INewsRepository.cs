
namespace Application.IRepositories;

public interface INewsRepository
{
    Task<PaginatedData<NewsEntity>> GetPaginatedNewsNotPublishedAsync(
        int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    
    Task<PaginatedData<NewsEntity>> GetPaginatedNewsAsync(
        int pageNumber, int pageSize, string searchTerms, string sortColumn, string sortOrder);
    Task<PaginatedData<NewsEntity>> GetPaginatedNewsByCategoryIdAsync(
        int categoryId, int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    Task<PaginatedData<NewsEntity>> GetPaginatedViewsNewsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    Task<PaginatedData<NewsEntity>> GetPaginatedLikesNewsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    Task<PaginatedData<NewsEntity>> GetPaginatedBookMarksNewsByUserIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    Task<PaginatedData<NewsEntity>> GetPaginatedNewsByAuthorIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder);
    
    Task<NewsEntity?> GetByIdAsync(Guid newsId);
    Task<NewsEntity?> GetByIdWithUserAndListsAsync(Guid newsId);
    
    Task CreateAsync(NewsEntity entity);
    Task UpdateAsync(NewsEntity entity);
    Task DeleteAsync(NewsEntity entity);

    Task<bool> IsExistByTitleAsync(string title);
    Task<bool> IsExistForUpdateByTitleAsync(Guid newsId, string title);
}
using Shared.Contracts.Requests.News;
using Shared.Contracts.Responses.News;

namespace Shared.IServices;

public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync();
    Task<Result<CategoryResponse>> GetByIdAsync(string categoryId);
    Task<Result> CreateAsync(CategoryRequest request);
    Task<Result> UpdateAsync(string categoryId, UpdateCategoryRequest request);
    Task<Result> DeleteAsync(string categoryId);
}
namespace Client.Infrastructure.Managers;

public interface ICategoryManager
{
    Task<IResult<IEnumerable<CategoryResponse>>> GetAllAsync();
    Task<IResult<CategoryResponse>> GetByIdAsync(string categoryId);
    Task<IResult> CreateAsync(CategoryRequest request);
    Task<IResult> UpdateAsync(string categoryId, UpdateCategoryRequest request);
    Task<IResult> DeleteAsync(string categoryId);
}

public class CategoryManager(
    IHttpClientFactory _factory)
    : ICategoryManager
{
    public async Task<IResult<IEnumerable<CategoryResponse>>> GetAllAsync()
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(CategoryRoutes.GetAll);
        return await response.ToResult<IEnumerable<CategoryResponse>>();
    }

    public async Task<IResult<CategoryResponse>> GetByIdAsync(string categoryId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(CategoryRoutes.GetById(categoryId));
        return await response.ToResult<CategoryResponse>();
    }

    public async Task<IResult> CreateAsync(CategoryRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PostAsJsonAsync(CategoryRoutes.Create, request);
        return await response.ToResult();
    }

    public async Task<IResult> UpdateAsync(string categoryId, UpdateCategoryRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(CategoryRoutes.Update(categoryId), request);
        return await response.ToResult();
    }

    public async Task<IResult> DeleteAsync(string categoryId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .DeleteAsync(CategoryRoutes.Delete(categoryId));
        return await response.ToResult();
    }
}
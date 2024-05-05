namespace Infrastructure.Services;

public class CategoryService(
    ICategoryRepository _categoryRepository)
    : ICategoryService
{
    public async Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync()
    {
        var categoriesEntity = await _categoryRepository.GetAllAsync();
        var categoriesResponse = categoriesEntity.Select(categoryEntity => new CategoryResponse(
            ID: categoryEntity.ID,
            Name: categoryEntity.Name,
            Description: categoryEntity.Description));
        return Result<IEnumerable<CategoryResponse>>
            .Success(categoriesResponse, "Категории новостей успешно получены!");
    }

    public async Task<Result<CategoryResponse>> GetByIdAsync(string categoryId)
    {
        var categoryEntity = await _categoryRepository
            .GetByIdAsync(Convert.ToInt32(categoryId));
        if (categoryEntity == null)
        {
            return Result<CategoryResponse>
                .Fail("Категория с данным идентификатором не существует!");
        }

        var categoryResponse = new CategoryResponse(
            ID: categoryEntity.ID,
            Name: categoryEntity.Name,
            Description: categoryEntity.Description);
        return Result<CategoryResponse>
            .Success(categoryResponse, "Информация о категории успешно получена.");
    }

    public async Task<Result> CreateAsync(CategoryRequest request)
    {
        var isNameExist = await _categoryRepository
            .IsExistByNameAsync(request.Name);
        if (isNameExist)
        {
            return Result<string>
                .Fail($"Категория с именем {request.Name} уже существует!");
        }

        var categoryEntity = new CategoryEntity
        {
            Name = request.Name,
            Description = request.Description,
            Created = DateTime.UtcNow
        };
        await _categoryRepository.CreateAsync(categoryEntity);
        return Result<string>
            .Success("Новая категория новостей успешно создана.");
    }

    public async Task<Result> UpdateAsync(string categoryId, UpdateCategoryRequest request)
    {
        var isNameExistForUpdate = await _categoryRepository
            .IsExistForUpdateByNameAsync(Convert.ToInt32(categoryId), request.Name);
        if (isNameExistForUpdate)
        {
            return Result<string>
                .Fail($"Категория с именем {request.Name} уже существует!");
        }
        var categoryEntity = await _categoryRepository
            .GetByIdAsync(Convert.ToInt32(categoryId));
        if (categoryEntity == null)
        {
            return Result<CategoryResponse>
                .Fail("Категория с данным идентификатором не существует!");
        }

        categoryEntity.Name = request.Name;
        categoryEntity.Description = request.Description;
        await _categoryRepository.UpdateAsync(categoryEntity);
        return Result<string>
            .Success("Категория успешно обновлена.");
    }

    public async Task<Result> DeleteAsync(string categoryId)
    {
        var categoryEntity = await _categoryRepository
            .GetByIdAsync(Convert.ToInt32(categoryId));
        if (categoryEntity == null)
        {
            return Result<CategoryResponse>
                .Fail("Категория с данным идентификатором не существует!");
        }

        await _categoryRepository.DeleteAsync(categoryEntity);
        return Result<string>
            .Success("Категория успешно удалена.");
    }
}
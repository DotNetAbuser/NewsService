namespace Application.IRepositories;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryEntity>> GetAllAsync();
    Task<CategoryEntity?> GetByIdAsync(int value);
    Task CreateAsync(CategoryEntity entity);
    
    Task UpdateAsync(CategoryEntity entity);

    
    Task<bool> IsExistByNameAsync(string name);
    Task<bool> IsExistForUpdateByNameAsync(int categoryId, string name);
    Task DeleteAsync(CategoryEntity entity);
}
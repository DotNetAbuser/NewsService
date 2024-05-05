namespace Infrastructure.Repositories;

public class CategoryRepository(
    ApplicationDbContext _dbContext)
    : ICategoryRepository
{
    public async Task<IEnumerable<CategoryEntity>> GetAllAsync()
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CategoryEntity?> GetByIdAsync(int value)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.ID == value);
    }

    public async Task CreateAsync(CategoryEntity entity)
    {
        await _dbContext.Categories.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(CategoryEntity entity)
    {
        _dbContext.Categories.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(CategoryEntity entity)
    {
        _dbContext.Categories.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> IsExistByNameAsync(string name)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .AnyAsync(x => x.Name == name);
    }

    public async Task<bool> IsExistForUpdateByNameAsync(int categoryId, string name)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .AnyAsync(x => x.ID != categoryId && x.Name == name);
    }


}
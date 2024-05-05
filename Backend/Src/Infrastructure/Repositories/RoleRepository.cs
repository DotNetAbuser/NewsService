namespace Infrastructure.Repositories;

public class RoleRepository(
    ApplicationDbContext _dbContext) 
    : IRoleRepository
{
    public async Task<IEnumerable<RoleEntity>> GetAllAsync()
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<RoleEntity?> GetByNameAsync(string value)
    {
        return await _dbContext.Roles
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Name == value);
    }
}
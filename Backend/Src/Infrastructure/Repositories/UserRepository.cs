namespace Infrastructure.Repositories;

public class UserRepository(
    ApplicationDbContext _dbContext)
    : IUserRepository
{
    public async Task<UserEntity?> GetByIdAsync(Guid userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.ID == userId);
    }
    
    public async Task<UserEntity?> GetByIdWithRoleAsync(Guid userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.ID == userId);
    }

    public async Task<UserEntity?> GetByUsernameWithRoleAsync(string username)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task<PaginatedData<UserEntity>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var query = _dbContext.Users
            .AsNoTracking();
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            query = query.Where(u =>
                u.LastName.Contains(searchTerms) ||
                u.FirstName.Contains(searchTerms) ||
                u.MiddleName.Contains(searchTerms) ||
                u.Username.Contains(searchTerms) ||
                u.Email.Contains(searchTerms) ||
                u.Phone.Contains(searchTerms));
        }
        
        Expression<Func<UserEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "lastname" => user => user.LastName,
            "firstname" => user => user.FirstName,
            "middlename" => user => user.MiddleName,
            "username" => user => user.Username,
            "email" => user => user.Email,
            "phone" => user => user.Phone,
            "isactive" => user => user.IsActive,
            _ => user => user.Created
        };
        
        query = sortOrder?.ToLower() == "desc" 
            ? query.OrderBy(keySelector) 
            : query.OrderByDescending(keySelector);
        var list = await query
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalCount = await _dbContext.Users
            .AsNoTracking()
            .CountAsync();
        return new PaginatedData<UserEntity>(
            List: list, TotalCount: totalCount);
    }
    
    public async Task CreateAsync(UserEntity entity)
    {
        await _dbContext.Users.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<bool> IsExistByUsername(string username)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Username == username);
    }

    public async Task<bool> IsExistByEmail(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsExistByPhone(string phone)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Phone == phone);
    }
    
    public async Task<bool> IsExistForUpdateByEmail(Guid userId, string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.ID != userId && x.Email == email);
    }

    public async Task<bool> IsExistForUpdateByPhone(Guid userId, string phone)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.ID != userId && x.Phone == phone);
    }
}
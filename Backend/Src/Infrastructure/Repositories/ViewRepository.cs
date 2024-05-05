namespace Infrastructure.Repositories;

public class ViewRepository(
    ApplicationDbContext _dbContext)
    : IViewRepository
{
    public async Task<bool> IsExistByUserIdAndNewsIdAsync(Guid userId, Guid newsId)
    {
        return await _dbContext.Views
            .AsNoTracking()
            .AnyAsync(x =>
                x.UserId == userId && x.NewsId == newsId);
    }

    public async Task CreateAsync(ViewEntity entity)
    {
        await _dbContext.Views.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
}
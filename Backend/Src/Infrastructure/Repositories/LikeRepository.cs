namespace Infrastructure.Repositories;

public class LikeRepository(
    ApplicationDbContext _dbContext) 
    : ILikeRepository
{ 
    public async Task<LikeEntity?> GetByUserIdAndNewsIdAsync(Guid userId, Guid newsId)
    {
        return await _dbContext.Likes
            .AsNoTracking()
            .SingleOrDefaultAsync(x =>
                x.UserId == userId && x.NewsId == newsId);
    }
    public async Task CreateAsync(LikeEntity entity)
    {
        await _dbContext.Likes.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(LikeEntity entity)
    {
        _dbContext.Likes.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByUserIdAndNewsId(Guid userId, Guid newsId)
    {
        return await _dbContext.Likes
            .AsNoTracking()
            .AnyAsync(x =>
                x.UserId == userId && x.NewsId == newsId);
    }
}
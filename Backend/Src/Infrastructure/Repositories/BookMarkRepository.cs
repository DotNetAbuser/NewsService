namespace Infrastructure.Repositories;

public class BookMarkRepository(
    ApplicationDbContext _dbContext)
    : IBookMarkRepository
{
    public async Task<BookMarkEntity?> GetByUserIdAndNewsIdAsync(Guid userId, Guid newsId)
    {
        return await _dbContext.BookMarks
            .AsNoTracking()
            .SingleOrDefaultAsync(x =>
                x.UserId == userId && x.NewsId == newsId);
    }

    public async Task CreateAsync(BookMarkEntity entity)
    {
        await _dbContext.BookMarks.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(BookMarkEntity entity)
    {
        _dbContext.BookMarks.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByUserIdAndNewsId(Guid userId, Guid newsId)
    {
        return await _dbContext.BookMarks
            .AsNoTracking()
            .AnyAsync(x =>
                x.UserId == userId && x.NewsId == newsId);
    }
}
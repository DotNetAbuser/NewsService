namespace Infrastructure.Repositories;

public class CommentRepository(
    ApplicationDbContext _dbContext) 
    : ICommentRepository
{
    public async Task<PaginatedData<CommentEntity>> GetPaginatedCommentsByNewsIdAsync(
        string newsId, 
        int pageNumber, int pageSize,
        string sortOrder)
    {
        var query = _dbContext.Comments
            .AsNoTracking();
        query = sortOrder?.ToLower() == "desc" 
            ? query.OrderBy(x => x.Created) 
            : query.OrderByDescending(x => x.Created);
        var list = await query
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.User)
            .ToListAsync();
        var totalCount = await _dbContext.Comments
            .AsNoTracking()
            .CountAsync();
        return new PaginatedData<CommentEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<CommentEntity?> GetByIdAsync(int commentId)
    {
        return await _dbContext.Comments
            .AsNoTracking()
            .SingleOrDefaultAsync(x =>
                x.ID == commentId);
    }

    public async Task CreateAsync(CommentEntity entity)
    {
        await _dbContext.Comments.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(CommentEntity entity)
    {
        _dbContext.Comments.Update(entity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(CommentEntity entity)
    {
        _dbContext.Comments.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

   
}
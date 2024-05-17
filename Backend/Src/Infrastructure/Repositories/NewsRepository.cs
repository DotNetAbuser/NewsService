namespace Infrastructure.Repositories;

public class NewsRepository(
    ApplicationDbContext _dbContext) 
    : INewsRepository
{
    public async Task<PaginatedData<NewsEntity>> GetPaginatedNewsNotPublishedAsync(int pageNumber, int pageSize, string? searchTerms, string? sortColumn,
        string? sortOrder)
    {
        var getListQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => !x.IsPublished);
        
        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => !x.IsPublished);
        
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        getListQuery = sortOrder?.ToLower() == "desc" 
            ? getListQuery.OrderBy(keySelector) 
            : getListQuery.OrderByDescending(keySelector);
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.Likes)
            .Include(x => x.BookMarks)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<NewsEntity>> GetPaginatedNewsAsync(
        int pageNumber, int pageSize,
        string searchTerms, string sortColumn, string sortOrder)
    {
        var getListQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.IsPublished);
        
        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.IsPublished);
        
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        getListQuery = sortOrder?.ToLower() == "desc" 
            ? getListQuery.OrderBy(keySelector) 
            : getListQuery.OrderByDescending(keySelector);
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.Likes)
            .Include(x => x.BookMarks)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }
    
    public async Task<PaginatedData<NewsEntity>> GetPaginatedNewsByCategoryIdAsync(
        int categoryId, 
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var getListQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.CategoryId == categoryId)
            .Where(x => x.IsPublished);
        
        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.CategoryId == categoryId)
            .Where(x => x.IsPublished);
        
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        getListQuery = sortOrder?.ToLower() == "desc" 
            ? getListQuery.OrderBy(keySelector) 
            : getListQuery.OrderByDescending(keySelector);
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.BookMarks)
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<NewsEntity>> GetPaginatedViewsNewsByUserIdAsync(
        Guid userId, 
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var getListQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.Views
                .Any(view => view.UserId == userId))
            .Where(x => x.IsPublished);

        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.Views
                .Any(view => view.UserId == userId))
            .Where(x => x.IsPublished);

        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        getListQuery = sortOrder?.ToLower() == "desc" 
            ? getListQuery.OrderBy(keySelector) 
            : getListQuery.OrderByDescending(keySelector);
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.BookMarks)
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<NewsEntity>> GetPaginatedLikesNewsByUserIdAsync(
        Guid userId,
        int pageNumber, int pageSize, 
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var getListQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.Likes
                .Any(like => like.UserId == userId))
            .Where(x => x.IsPublished);

        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.Likes
                .Any(like => like.UserId == userId))
            .Where(x => x.IsPublished);
        
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        getListQuery = sortOrder?.ToLower() == "desc" 
            ? getListQuery.OrderBy(keySelector) 
            : getListQuery.OrderByDescending(keySelector);
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.BookMarks)
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<NewsEntity>> GetPaginatedBookMarksNewsByUserIdAsync(
        Guid userId, 
        int pageNumber, int pageSize, 
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var getListQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.BookMarks
                .Any(bookmark => bookmark.UserId == userId))
            .Where(x => x.IsPublished);

        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.BookMarks
                .Any(bookmark => bookmark.UserId == userId))
            .Where(x => x.IsPublished);

        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            getListQuery = getListQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        getListQuery = sortOrder?.ToLower() == "desc" 
            ? getListQuery.OrderBy(keySelector) 
            : getListQuery.OrderByDescending(keySelector);
        var list = await getListQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.BookMarks)
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<PaginatedData<NewsEntity>> GetPaginatedNewsByAuthorIdAsync(
        Guid userId, int pageNumber, int pageSize, string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var query = _dbContext.News
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Where(x => x.IsPublished);
        var countQuery = _dbContext.News
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Where(x => x.IsPublished);
        if (!string.IsNullOrWhiteSpace(searchTerms))
        {
            searchTerms = searchTerms.ToLower();
            query = query.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
            
            countQuery = countQuery.Where(u =>
                u.Title.ToLower().Contains(searchTerms) ||
                u.Content.ToLower().Contains(searchTerms));
        }
        
        Expression<Func<NewsEntity, object>> keySelector = sortColumn?.ToLower() switch
        {
            "views" => news => news.Views.Count,
            "likes" => news => news.Likes.Count,
            "comments" => news => news.Comments.Count,
            _ => news => news.Created
        };
        
        query = sortOrder?.ToLower() == "desc" 
            ? query.OrderBy(keySelector) 
            : query.OrderByDescending(keySelector);
        var list = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.BookMarks)
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .ToListAsync();
        var totalCount = await countQuery
            .CountAsync();
        return new PaginatedData<NewsEntity>(
            List: list, TotalCount: totalCount);
    }

    public async Task<NewsEntity?> GetByIdAsync(Guid newsId)
    {
        return await _dbContext.News
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.ID == newsId);
    }

    public async Task<NewsEntity?> GetByIdWithUserAndListsAsync(Guid newsId)
    {
        return await _dbContext.News
            .AsNoTracking()
            .Include(x => x.Category)
            .Include(x => x.User)
            .Include(x => x.Views)
            .Include(x => x.BookMarks)
            .Include(x => x.Likes)
            .Include(x => x.Comments)
            .SingleOrDefaultAsync(x => x.ID == newsId);
    }

    public async Task CreateAsync(NewsEntity entity)
    {
        await _dbContext.News.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(NewsEntity entity)
    {
        _dbContext.News.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(NewsEntity entity)
    {
        _dbContext.News.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByTitleAsync(string title)
    {
        return await _dbContext.News
            .AsNoTracking()
            .AnyAsync(x => x.Title == title);
    }

    public async Task<bool> IsExistForUpdateByTitleAsync(Guid newsId, string title)
    {
        return await _dbContext.News
            .AsNoTracking()
            .AnyAsync(x => x.ID != newsId && x.Title == title);
    }
}
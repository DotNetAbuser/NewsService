namespace Application.IRepositories;

public interface IBookMarkRepository
{
    Task<BookMarkEntity?> GetByUserIdAndNewsIdAsync(Guid userId, Guid newsId);
    Task CreateAsync(BookMarkEntity entity);
    Task DeleteAsync(BookMarkEntity entity);

    Task<bool> IsExistByUserIdAndNewsId(Guid userId, Guid newsId);
}
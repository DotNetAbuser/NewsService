namespace Application.IRepositories;

public interface ILikeRepository
{
    Task<LikeEntity?> GetByUserIdAndNewsIdAsync(Guid userId, Guid newsId);
    Task CreateAsync(LikeEntity entity);
    Task DeleteAsync(LikeEntity entity);

    Task<bool> IsExistByUserIdAndNewsId(Guid userId, Guid newsId);
}
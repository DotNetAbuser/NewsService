namespace Application.IRepositories;

public interface IViewRepository
{
    Task<bool> IsExistByUserIdAndNewsIdAsync(Guid userId, Guid newsId);
    Task CreateAsync(ViewEntity entity);
}
namespace Application.IRepositories;

public interface ISessionRepository
{
    Task<SessionEntity?> GetByRefreshTokenAsync(string value);

    Task CreateAsync(SessionEntity entity);
    Task DeleteAsync(SessionEntity entity);
}
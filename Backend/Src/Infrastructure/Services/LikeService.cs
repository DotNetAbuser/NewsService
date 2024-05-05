namespace Infrastructure.Services;

public class LikeService(
    IHttpContextAccessor _httpContextAccessor,
    IUserRepository _userRepository,
    INewsRepository _newsRepository,
    ILikeRepository _likeRepository)
    : ILikeService
{
    public async Task<Result> CreateAsync(
        string newsId, CreateLikeRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = currentUserId == request.UserId;
        if (!isCurrentUser)
        {
            return Result<string>
                .Fail("Пользователь не может ставить лайки с чужой учётной записи!");
        }
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(request.UserId));
        if (userEntity == null)
        {
            return Result<string>
                .Fail("Пользователь не сущетсвует в системе!");
        }
        var newsEntity = await _newsRepository
            .GetByIdAsync(Guid.Parse(newsId));
        if (newsEntity == null)
        {
            return Result<string>
                .Fail("Новость не существует!");
        }
        var isAlreadyLiked = await _likeRepository
            .IsExistByUserIdAndNewsId(userEntity.ID, newsEntity.ID);
        if (isAlreadyLiked)
        {
            return Result<string>
                .Fail("Лайк под этой новостью уже был поставлен ранее!");
        }
        var likeEntity = new LikeEntity
        {
            UserId = userEntity.ID,
            NewsId = newsEntity.ID,
            Created = DateTime.UtcNow
        };
        await _likeRepository.CreateAsync(likeEntity);
        return Result<string>
            .Success("Лайк под новостью успешно поставлен");
    }

    public async Task<Result> DeleteAsync(
        string newsId)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(currentUserId));
        if (userEntity == null)
        {
            return Result<string>
                .Fail("Пользователь не сущетсвует в системе!");
        }
        var newsEntity = await _newsRepository
            .GetByIdAsync(Guid.Parse(newsId));
        if (newsEntity == null)
        {
            return Result<string>
                .Fail("Новость не существует!");
        }
        var likeEntity = await _likeRepository
            .GetByUserIdAndNewsIdAsync(userEntity.ID, newsEntity.ID);
        if (likeEntity == null)
        {
            return Result<string>
                .Fail("Лайк под данной новостью не поставлен!");
        }

        await _likeRepository.DeleteAsync(likeEntity);
        return Result<string>
            .Success("Лайк успешно убран с новости.");
    }
}
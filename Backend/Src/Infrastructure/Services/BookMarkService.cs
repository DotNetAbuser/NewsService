namespace Infrastructure.Services;

public class BookMarkService(
    IHttpContextAccessor _httpContextAccessor,
    IUserRepository _userRepository,
    INewsRepository _newsRepository,
    IBookMarkRepository _bookMarkRepository) 
    : IBookMarkService
{
    public async Task<Result> CreateAsync(string newsId, CreateBookMarkRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = currentUserId == request.UserId;
        if (!isCurrentUser)
        {
            return Result<string>
                .Fail("Пользователь не может добавлять новость в закладки с чужой учётной записи!");
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
        var isAlreadyBookMarked = await _bookMarkRepository
            .IsExistByUserIdAndNewsId(userEntity.ID, newsEntity.ID);
        if (isAlreadyBookMarked)
        {
            return Result<string>
                .Fail("Новость уже находится в закладках!");
        }
        var bookMarkEntity = new BookMarkEntity
        {
            UserId = userEntity.ID,
            NewsId = newsEntity.ID,
            Created = DateTime.UtcNow
        };
        await _bookMarkRepository.CreateAsync(bookMarkEntity);
        return Result<string>
            .Success("Новость успешно добавлена в закладки.");
    }

    public async Task<Result> DeleteAsync(string newsId)
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
        var bookMarkEntity = await _bookMarkRepository
            .GetByUserIdAndNewsIdAsync(userEntity.ID, newsEntity.ID);
        if (bookMarkEntity == null)
        {
            return Result<string>
                .Fail("Новость на находится в закладках!");
        }
        await _bookMarkRepository.DeleteAsync(bookMarkEntity);
        return Result<string>
            .Success("Новость убрана из закладок.");
    }
}
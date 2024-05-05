namespace Infrastructure.Services;

public class CommentService(
    IHttpContextAccessor _httpContextAccessor,
    IUserRepository _userRepository,
    INewsRepository _newsRepository,
    ICommentRepository _commentRepository)
    : ICommentService
{
    public async Task<Result<PaginatedData<CommentResponse>>> GetPaginatedCommentsByNewsIdAsync(
        string newsId,
        int pageNumber, int pageSize,
        string sortOrder)
    {
        var (commentsEntities, totalCount) = await _commentRepository
            .GetPaginatedCommentsByNewsIdAsync(
                newsId,
                pageNumber, pageSize,
                sortOrder);
        var commentsResponse = commentsEntities
            .Select(commentEntity => new CommentResponse(
                ID: commentEntity.ID,
                AuthorLastName: commentEntity.User.LastName,
                AuthorFirstName: commentEntity.User.FirstName,
                AuthorMiddleName: commentEntity.User.MiddleName,
                Content: commentEntity.Content,
                Created: commentEntity.Created,
                Updated: commentEntity.Updated)).ToList();
        var paginatedCommentsResponse = new PaginatedData<CommentResponse>(
            List: commentsResponse, TotalCount: totalCount);
        return Result<PaginatedData<CommentResponse>>
            .Success(paginatedCommentsResponse, "Комментарии к новости успешно получены!");
    }

    public async Task<Result> CreateAsync(string newsId, CreateCommentRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = currentUserId == request.UserId;
        if (!isCurrentUser)
        {
            return Result<string>
                .Fail("Невозможно оставлять комментарии через чужого пользователя!");
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
        
        var commentEntity = new CommentEntity
        {
            UserId = userEntity.ID,
            NewsId = newsEntity.ID,
            Content = request.Content,
            Created = DateTime.UtcNow
        };
        await _commentRepository.CreateAsync(commentEntity);
        return Result<string>
            .Success("Комментарий успешно оставлен под новостью.");
    }

    public async Task<Result> UpdateAsync(string commentId, UpdateCommentRequest request)
    {
        var commentEntity = await _commentRepository
            .GetByIdAsync(Convert.ToInt32(commentId));
        if (commentEntity == null)
        {
            return Result<string>
                .Fail("Комментарий не найден!");
        }
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = currentUserId == commentEntity.UserId.ToString();
        if (!isCurrentUser)
        {
            return Result<string>
                .Fail("Невозможно оставлять комментарии через чужого пользователя!");
        }
        commentEntity.Content = request.Content;
        commentEntity.Updated = DateTime.UtcNow;
        await _commentRepository.UpdateAsync(commentEntity);
        return Result<string>
            .Success("Комментарий успешно изменён.");
    }

    public async Task<Result> DeleteAsync(string commentId)
    {
        var commentEntity = await _commentRepository
            .GetByIdAsync(Convert.ToInt32(commentId));
        if (commentEntity == null)
        {
            return Result<string>
                .Fail("Комментарий не найден!");
        }
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = currentUserId == commentEntity.UserId.ToString();
        var currentUserRole = claims.GetLoggedInUserRole<string>();
        var isCurrentUserRoleAdmin = currentUserRole == Role.Admin.ToString();
        if (!isCurrentUser && !isCurrentUserRoleAdmin)
        {
            return Result<string>
                .Fail("Для удаления не своего комментария нужно иметь роль Админа!");
        }

        await _commentRepository.DeleteAsync(commentEntity);
        return Result<string>
            .Fail("Комментарий успешно удалён.");
    }
}
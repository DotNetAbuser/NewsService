
namespace Application.IRepositories;

public interface ICommentRepository
{
    Task<PaginatedData<CommentEntity>> GetPaginatedCommentsByNewsIdAsync(
        string newsId,
        int pageNumber, int pageSize,
        string sortOrder);
    Task<CommentEntity?> GetByIdAsync(int commentId);
    Task CreateAsync(CommentEntity entity);
    Task DeleteAsync(CommentEntity entity);
    Task UpdateAsync(CommentEntity entity);
}
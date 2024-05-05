using Shared.Contracts;
using Shared.Contracts.Responses.News;

namespace Shared.IServices;

public interface ICommentService
{
    Task<Result<PaginatedData<CommentResponse>>> GetPaginatedCommentsByNewsIdAsync(
        string newsId,
        int pageNumber, int pageSize,
        string sortOrder);

    Task<Result> CreateAsync(string newsId, CreateCommentRequest request);
    Task<Result> UpdateAsync(string commentId, UpdateCommentRequest request);
    Task<Result> DeleteAsync(string commentId);
}
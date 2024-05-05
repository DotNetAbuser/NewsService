namespace Client.Infrastructure.Managers;

public interface ICommentManager
{
    Task<IResult<PaginatedData<CommentResponse>>> GetPaginatedCommentsByNewsIdAsync(
        string newsId,
        int pageNumber, int pageSize,
        string sortOrder);

    Task<IResult> CreateAsync(string newsId, CreateCommentRequest request);
    Task<IResult> UpdateAsync(string commentId, UpdateCommentRequest request);
    Task<IResult> DeleteAsync(string commentId);
}

public class CommentManager(
    IHttpClientFactory _factory)
    : ICommentManager
{
    public async Task<IResult<PaginatedData<CommentResponse>>> GetPaginatedCommentsByNewsIdAsync(
        string newsId,
        int pageNumber, int pageSize,
        string sortOrder)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .GetAsync(CommentRoutes.GetPaginatedCommentsById(newsId, pageNumber, pageSize, sortOrder));
        return await response.ToResult<PaginatedData<CommentResponse>>();
    }

    public async Task<IResult> CreateAsync(string newsId, CreateCommentRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PostAsJsonAsync(CommentRoutes.CommentTheNews(newsId), request);
        return await response.ToResult();
    }

    public async Task<IResult> UpdateAsync(string commentId, UpdateCommentRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PutAsJsonAsync(CommentRoutes.UpdateCommentTheNews(commentId), request);
        return await response.ToResult();
    }

    public async Task<IResult> DeleteAsync(string commentId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .DeleteAsync(CommentRoutes.RemoveCommentFromNews(commentId));
        return await response.ToResult();
    }
}
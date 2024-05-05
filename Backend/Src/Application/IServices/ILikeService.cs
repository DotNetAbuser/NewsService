using Shared.Contracts.Responses.News;

namespace Shared.IServices;

public interface ILikeService
{
    Task<Result> CreateAsync(string newsId, CreateLikeRequest request);
    Task<Result> DeleteAsync(string newsId);
}
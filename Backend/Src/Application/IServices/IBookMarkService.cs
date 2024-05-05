using Shared.Contracts.Responses.News;

namespace Shared.IServices;

public interface IBookMarkService
{
    Task<Result> CreateAsync(string newsId, CreateBookMarkRequest request);
    Task<Result> DeleteAsync(string newsId);
}
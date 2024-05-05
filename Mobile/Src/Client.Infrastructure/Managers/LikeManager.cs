namespace Client.Infrastructure.Managers;

public interface ILikeManager
{
    Task<IResult> CreateAsync(string newsId, CreateLikeRequest request);
    Task<IResult> DeleteAsync(string newsId);
}

public class LikeManager(
    IHttpClientFactory _factory)
    : ILikeManager
{
    public async Task<IResult> CreateAsync(string newsId, CreateLikeRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PostAsJsonAsync(LikeRoutes.LikeTheNews(newsId), request);
        return await response.ToResult();
    }

    public async Task<IResult> DeleteAsync(string newsId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .DeleteAsync(LikeRoutes.RemoveLikeFromNews(newsId));
        return await response.ToResult();
    }
}
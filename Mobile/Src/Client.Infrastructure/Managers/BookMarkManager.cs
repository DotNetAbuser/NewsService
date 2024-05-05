namespace Client.Infrastructure.Managers;

public interface IBookMarkManager
{
    Task<IResult> CreateAsync(string newsId, CreateBookMarkRequest request);
    Task<IResult> DeleteAsync(string newsId);
}

public class BookMarkManager(
    IHttpClientFactory _factory)
    : IBookMarkManager
{
    public async Task<IResult> CreateAsync(string newsId, CreateBookMarkRequest request)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .PostAsJsonAsync(BookMarkRoutes.BookMarkTheNews(newsId), request);
        return await response.ToResult();
    }

    public async Task<IResult> DeleteAsync(string newsId)
    {
        var response = await _factory.CreateClient(ApplicationConstants.BaseClient)
            .DeleteAsync(BookMarkRoutes.RemoveNewsFromBookMark(newsId));
        return await response.ToResult();
    }
}
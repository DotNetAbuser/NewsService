namespace Server.Controllers.News;

[ApiController]
[Route("api/news")]
public class BookMarkController(
    IBookMarkService _bookMarkService) 
    : ControllerBase
{
    [HttpPost("{newsId}/bookmark")]
    [Authorize]
    public async Task<IActionResult> CreateAsync(
        string newsId, CreateBookMarkRequest request)
    {
        return Ok(await _bookMarkService.CreateAsync(newsId, request));
    }

    [HttpDelete("{newsId}/bookmark")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync(
        string newsId)
    {
        return Ok(await _bookMarkService.DeleteAsync(newsId));
    }
}
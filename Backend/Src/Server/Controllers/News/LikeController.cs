namespace Server.Controllers.News;

[ApiController]
[Route("api/news")]
public class LikeController(
    ILikeService _likeService)
    : ControllerBase
{
    [HttpPost("{newsId}/like")]
    [Authorize]
    public async Task<IActionResult> LikeTheNewsAsync(
        string newsId, CreateLikeRequest request)
    {
        return Ok(await _likeService.CreateAsync(newsId, request));
    }

    [HttpDelete("{newsId}/like")]
    [Authorize]
    public async Task<IActionResult> RemoveLikeFromNewsAsync(
        string newsId)
    {
        return Ok(await _likeService.DeleteAsync(newsId));
    }
}
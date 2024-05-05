namespace Server.Controllers.News;

[ApiController]
[Route("api/news")]
public class CommentController(
    ICommentService _commentService)
    : ControllerBase
{
    [HttpGet("{newsId}/comment")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedCommentsByIdAsync(
        string newsId,
        int pageNumber, int pageSize,
        string? sortOrder)
    {
        var response = await _commentService
            .GetPaginatedCommentsByNewsIdAsync(
                newsId,
                pageNumber, pageSize,
                sortOrder);
        return Ok(response);
    }
    
    [HttpPost("{newsId}/comment")]
    [Authorize]
    public async Task<IActionResult> CommentTheNewsAsync( 
        string newsId, CreateCommentRequest request)
    {
        return Ok(await _commentService.CreateAsync(newsId, request));
    }
    
    [HttpPut("comment/{commentId}")]
    [Authorize]
    public async Task<IActionResult> UpdateCommentTheNewsAsync(
        string commentId, UpdateCommentRequest request)
    {
        return Ok(await _commentService.UpdateAsync(commentId, request));
    }

    [HttpDelete("comment/{commentId}")]
    [Authorize]
    public async Task<IActionResult> RemoveCommentFromNewsAsync(string commentId)
    {
        return Ok(await _commentService.DeleteAsync(commentId));
    }
}
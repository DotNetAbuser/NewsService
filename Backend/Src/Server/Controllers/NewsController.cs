using Application.IServices;

namespace Server.Controllers;

[ApiController]
[Route("api/news")]
public class NewsController(
    INewsService _newsService)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPaginatedNewsAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _newsService.GetPaginatedNewsAsync(
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        return Ok(response);
    }

    [HttpGet("{newsId}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(string newsId)
    {
        var response = await _newsService.GetByIdAsync(newsId);
        return Ok(response);
    }

    [HttpGet("{categoryId}/category")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedNewsByCategoryId(
        int categoryId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _newsService.GetPaginatedNewsByCategoryIdAsync(
            categoryId,
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        return Ok(response);
    }
    
    [HttpGet("{userId}/views")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedViewsNewsByUserId(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _newsService.GetPaginatedViewsNewsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        return Ok(response);
    }
    
    [HttpGet("{userId}/likes")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedLikesNewsByUserId(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _newsService.GetPaginatedLikesNewsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        return Ok(response);
    }
    
    [HttpGet("{userId}/bookmarks")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedBookMarksNewsByUserId(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _newsService.GetPaginatedBookMarksNewsByUserIdAsync(
            userId,
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        return Ok(response);
    }

    [HttpGet("{userId}/by-author")]
    [Authorize]
    public async Task<IActionResult> GetPaginatedNewsByAuthorIdAsync(
        string userId,
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _newsService.GetPaginatedNewsByAuthorId(
            userId,
            pageNumber, pageSize,
            searchTerms, sortColumn,sortOrder);
        return Ok(response);
    }
    

    [HttpPost]
    [Authorize(Roles = "Admin, Journalist")]
    public async Task<IActionResult> CreateAsync(CreateNewsRequest request)
    {
        var response = await _newsService.CreateAsync(request);
        return Ok(response);
    }
    
    [HttpPut("{newsId}")]
    [Authorize(Roles = "Admin, Journalist")]
    public async Task<IActionResult> UpdateAsync(string newsId, UpdateNewsRequest request)
    {
        return Ok(await _newsService.UpdateAsync(newsId, request));
    }

    [HttpDelete("{newsId}")]
    [Authorize(Roles = "Admin, Journalist")]
    public async Task<IActionResult> DeleteAsync(string newsId)
    {
        return Ok(await _newsService.DeleteAsync(newsId));
    }
}
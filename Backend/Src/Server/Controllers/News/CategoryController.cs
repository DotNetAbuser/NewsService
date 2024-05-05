namespace Server.Controllers.News;

[ApiController]
[Route("api/news/category")]
public class CategoryController(
    ICategoryService _categoryService)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _categoryService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{categoryId}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(string categoryId)
    {
        var response = await _categoryService.GetByIdAsync(categoryId);
        return Ok(response);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync(CategoryRequest request)
    {
        return Ok(await _categoryService.CreateAsync(request));
    }

    [HttpPut("{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(string categoryId, UpdateCategoryRequest request)
    {
        return Ok(await _categoryService.UpdateAsync(categoryId, request));
    }

    [HttpDelete("{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(string categoryId)
    {
        return Ok(await _categoryService.DeleteAsync(categoryId));
    }

}
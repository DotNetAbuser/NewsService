namespace Server.Controllers.Identity;

[ApiController]
[Route("api/identity/user")]
public class UserController(
    IUserService _userService)
    : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetPaginatedUserAsync(
        int pageNumber, int pageSize,
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var response = await _userService.GetPaginatedUsersAsync(
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder);
        return Ok(response);
    }

    [HttpGet("{userId}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(string userId)
    {
        var response = await _userService.GetByIdAsync(userId);
        return Ok(response);
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpAsync(SignUpRequest request)
    {
        return Ok(await _userService.CreateAsync(request));
    }

    [HttpGet("{userId}/role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetRolesByIdAsync(string userId)
    {
        var response = await _userService.GetRolesByIdAsync(userId);
        return Ok(response);
    }

    [HttpPut("{userId}/role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateRolesAsync(string userId, UpdateUserRolesRequest request)
    {
        return Ok(await _userService.UpdateRolesAsync(userId, request));
    }

    [HttpPut("{userId}/toggle-status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ToggleStatusAsync(string userId, ToggleUserStatusRequest request)
    {
        return Ok(await _userService.ToggleStatusAsync(userId, request));
    }
}
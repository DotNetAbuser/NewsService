namespace Server.Controllers.Identity;

[ApiController]
[Route("api/identity/account")]
public class AccountController(
    IAccountService _accountService)
    : ControllerBase
{

    [HttpPut("{userId}/update-profile")]
    [Authorize]
    public async Task<IActionResult> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        return Ok(await _accountService.UpdateProfileAsync(userId, request));
    }

    [HttpPut("{userId}/change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        return Ok(await _accountService.ChangePasswordAsync(userId, request));
    }
    
}
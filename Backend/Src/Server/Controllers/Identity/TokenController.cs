namespace Server.Controllers.Identity;

[ApiController]
[Route("api/identity/token")]
public class TokenController(
    ITokenService _tokenService)
    : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignInAsync(TokenRequest request)
    {
        var response = await _tokenService.SignInAsync(request);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var response = await _tokenService.RefreshTokenAsync(request);
        return Ok(response);
    }
}
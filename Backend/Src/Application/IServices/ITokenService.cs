using Shared.Contracts.Requests.Identity;
using Shared.Contracts.Responses.Identity;

namespace Shared.IServices;

public interface ITokenService
{
    Task<Result<TokenResponse>> SignInAsync(TokenRequest request);
    Task<Result<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request);
}
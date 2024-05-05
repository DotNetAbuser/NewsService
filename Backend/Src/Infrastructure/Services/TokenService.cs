namespace Infrastructure.Services;

public class TokenService(
    IRoleRepository _roleRepository,
    ISessionRepository _sessionRepository,
    IUserRepository _userRepository,
    IPasswordHasher _passwordHasher,
    IConfiguration configuration)
    : ITokenService
{
    public async Task<Result<TokenResponse>> SignInAsync(TokenRequest request)
    {
        var userEntity = await _userRepository
            .GetByUsernameWithRoleAsync(request.Username);
        if (userEntity == null)
        {
            return Result<TokenResponse>
                .Fail($"Пользователь с {request.Username} не существует!");
        }
        var isCorrectPassword = _passwordHasher
            .Verify(request.Password, userEntity.PasswordHash);
        if (!isCorrectPassword)
        {
            return Result<TokenResponse>
                .Fail("Неправильный введённый пароль!");
        }
        var isUserActive = userEntity.IsActive;
        if (!isUserActive)
        {
            return Result<TokenResponse>
                .Fail("Профиль пользователя неактивен! " +
                      "Обратитесь в поддержку для выяснения причины блокировки.");
        }

        var authToken = generateJwtToken(userEntity);
        var refreshToken = generateRefreshToken();
        var sessionEntity = new SessionEntity
        {
            UserId = userEntity.ID,
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow
        };
        await _sessionRepository.CreateAsync(sessionEntity);
        var response = new TokenResponse(
            AuthToken: authToken,
            RefreshToken: refreshToken);
        return Result<TokenResponse>
            .Success(response, "Пользователь успешно прошёл аунтификацию.");
    }

    public async Task<Result<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var refreshSessionEntity = await _sessionRepository
            .GetByRefreshTokenAsync(request.RefreshToken);
        if (refreshSessionEntity == null)
        {
            return Result<TokenResponse>
                .Fail("Сессии не существует, необходимо пройти аунтификацию!");
        }
        if (refreshSessionEntity.Expires < DateTime.UtcNow)
        {
            await _sessionRepository.DeleteAsync(refreshSessionEntity);
            return Result<TokenResponse>
                .Fail("Сессия устарела, необходимо вновь пройти аунтификацию!");
        }
        var userEntity = await _userRepository.GetByIdWithRoleAsync(refreshSessionEntity.UserId);
        if (userEntity == null)
        {
            await _sessionRepository.DeleteAsync(refreshSessionEntity);
            return Result<TokenResponse>
                .Fail("Пользователя не найден!");
        }
        await _sessionRepository.DeleteAsync(refreshSessionEntity);
        var newAuthToken = generateJwtToken(userEntity);
        var newRefreshToken = generateRefreshToken();
        var newRefreshSessionEntity = new SessionEntity
        {
            UserId = userEntity.ID,
            Token = newRefreshToken,
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow
        };
        await _sessionRepository
            .CreateAsync(newRefreshSessionEntity);
        var tokenResponse = new TokenResponse(
            AuthToken: newAuthToken,
            RefreshToken: newRefreshToken);
        return Result<TokenResponse>
            .Success(tokenResponse, "Новый пара токенов успешно получены.");
    }
    
    private string generateJwtToken(UserEntity user) =>
        generateEncryptedToken(getSigningCredentials(), getClaims(user));

    private IEnumerable<Claim> getClaims(UserEntity user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.ID.ToString()),
            new(ClaimTypes.Role, user.Role.Name)
        };

        return claims;
    }

    private string generateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var expiresStr = configuration.GetSection("JwtOptions:Expires").Value 
                         ?? throw new ArgumentNullException("Expires minutes is missing");
        var expiresMinutes = Convert.ToInt32(expiresStr);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: signingCredentials);
        var tokenHandler = new JwtSecurityTokenHandler();
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }

    private string generateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private SigningCredentials getSigningCredentials()
    {
        var secretKey = configuration.GetSection("JwtOptions:SecretKey").Value 
                        ?? throw new ArgumentException("Secret key is missing");
        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        return new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
    }
}
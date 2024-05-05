namespace Infrastructure.Services;

public class AccountService(
    IHttpContextAccessor _httpContextAccessor,
    IUserRepository _userRepository,
    IPasswordHasher _passwordHasher)
    : IAccountService
{
    public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = userId == currentUserId;
        var currentUserRole = claims.GetLoggedInUserRole<string>();
        var isCurrentUserAdmin = currentUserRole == Role.Admin.ToString();
        if (!isCurrentUser && !isCurrentUserAdmin)
        {
            return Result<string>
                .Fail("Для изменения не своего профиля нужно иметь роль Админа!");
        }

        var isEmailExistForUpdate = await _userRepository
            .IsExistForUpdateByEmail(Guid.Parse(userId), request.Email);
        if (isEmailExistForUpdate)
        {
            return Result<string>
                .Fail("Пользователь с такой эл. почтой уже существует!");
        }

        var isPhoneExistForUpdate = await _userRepository
            .IsExistForUpdateByPhone(Guid.Parse(userId), request.Phone);
        if (isPhoneExistForUpdate)
        {
            return Result<string>
                .Fail("Пользователь с таким номером телефона уже существует!");
        }
        
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(userId));
        if (userEntity == null)
        {
            return Result<string>
                .Fail("Пользователь с данным идентификатором не существует!");
        }
        userEntity.LastName = request.LastName;
        userEntity.FirstName = request.FirstName;
        userEntity.MiddleName = request.MiddleName;
        userEntity.Email = request.Email;
        userEntity.Phone = request.Phone;
        await _userRepository.UpdateAsync(userEntity);
        return Result<string>
            .Success("Профиль пользователя успешно изменён!");
    }

    public async Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = userId == currentUserId;
        var currentUserRole = claims.GetLoggedInUserRole<string>();
        var isCurrentUserAdmin = currentUserRole == Role.Admin.ToString();
        if (!isCurrentUser && !isCurrentUserAdmin)
        {
            return Result<string>
                .Fail("Для изменения пароля не своей учётной записи нужно иметь роль Админа!");
        }
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(userId));
        if (userEntity == null)
        {
            return Result<string>
                .Fail("Пользователь с данным идентификатором не существует!");
        }
        var isPasswordCorrect = _passwordHasher
            .Verify(request.OldPassword, userEntity.PasswordHash);
        if (!isPasswordCorrect)
        {
            return Result<string>
                .Fail("Неправильный старый пароль!");
        }
        userEntity.PasswordHash = _passwordHasher.Generate(request.NewPassword);
        await _userRepository.UpdateAsync(userEntity);
        return Result<string>
            .Success("Пароль успешно изменён.");
    }
}
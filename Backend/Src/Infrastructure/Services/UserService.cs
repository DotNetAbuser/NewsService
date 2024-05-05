namespace Infrastructure.Services;

public class UserService(
    IHttpContextAccessor _httpContextAccessor,
    IUserRepository _userRepository,
    IRoleRepository _roleRepository,
    IPasswordHasher _passwordHasher)
    : IUserService
{
    public async Task<Result<PaginatedData<UserResponse>>> GetPaginatedUsersAsync(
        int pageNumber, int pageSize, 
        string? searchTerms, string? sortColumn, string? sortOrder)
    {
        var (usersEntities, totalCount) = await _userRepository.GetPaginatedUsersAsync(
            pageNumber, pageSize,
            searchTerms, sortColumn, sortOrder); 
        var usersResponse = usersEntities
            .Select(userEntity => new UserResponse(
                ID: userEntity.ID.ToString(),
                ProfilePictureUrl: userEntity.ProfilePictureUrl,
                LastName: userEntity.LastName,
                FirstName: userEntity.FirstName,
                MiddleName: userEntity.MiddleName,
                Username: userEntity.Username,
                Email: userEntity.Email,
                Phone: userEntity.Phone,
                IsActive: userEntity.IsActive,
                Created: userEntity.Created)).ToList();
        var paginatedUsersResponse = new PaginatedData<UserResponse>(
            List: usersResponse, TotalCount: totalCount);
        return Result<PaginatedData<UserResponse>>
            .Success(paginatedUsersResponse, "Список пользователей успешно получен.");
    }
    
    public async Task<Result<UserResponse>> GetByIdAsync(string userId)
    {
        var userEntity = await _userRepository.GetByIdAsync(Guid.Parse(userId));
        if (userEntity == null)
        {
            return Result<UserResponse>
                .Fail("Пользователь под данным идентификатором не найден!");
        }
        var userResponse = new UserResponse(
            ID: userEntity.ID.ToString(),
            ProfilePictureUrl: userEntity.ProfilePictureUrl,
            LastName: userEntity.LastName,
            FirstName: userEntity.FirstName,
            MiddleName: userEntity.MiddleName,
            Username: userEntity.Username,
            Email: userEntity.Email,
            Phone: userEntity.Phone,
            IsActive: userEntity.IsActive,
            Created: userEntity.Created);
        return Result<UserResponse>
            .Success(userResponse, "Информация о пользователе успешно получена.");
    }
    
    public async Task<Result> CreateAsync(SignUpRequest request)
    {
        var usernameIsExist = await _userRepository
            .IsExistByUsername(request.Username);
        if (usernameIsExist)
        {
            return Result<string>
                .Fail("Пользователь с таким именем пользователя уже существует!");
        }
        var emailIsExist = await _userRepository
            .IsExistByEmail(request.Email);
        if (emailIsExist)
        {
            return Result<string>
                .Fail("Пользователь с такой эл. почтой уже существует!");
        }
        var phoneIsExist = await _userRepository
            .IsExistByPhone(request.Phone);
        if (phoneIsExist)
        {
            return Result<string>
                .Fail("Пользователь с таким номером телефона уже существует!");
        }
        var userEntity = new UserEntity
        {
            RoleId = (int)Role.Guest,
            LastName = request.LastName,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            Username = request.Username,
            PasswordHash = _passwordHasher.Generate(request.Password),
            Email = request.Email,
            Phone = request.Phone,
            IsActive = true,
            Created = DateTime.UtcNow
        };
        await _userRepository.CreateAsync(userEntity);

        return Result<string>
            .Success("Пользователь успешно зарегистрирован.");
    }
   
    public async Task<Result<UserRolesResponse>> GetRolesByIdAsync(string userId)
    {
        var rolesEntities = await _roleRepository.GetAllAsync();
        var userEntity = await _userRepository.GetByIdWithRoleAsync(Guid.Parse(userId));
        var response = new UserRolesResponse
        {
            UserRoles = rolesEntities.Select(roleEntity => new UserRole(
                Name: roleEntity.Name,
                Selected: roleEntity.Name == userEntity.Role.Name)).ToList()
        };
        return Result<UserRolesResponse>
            .Success(response, "Роли пользователя успешно получены.");
    }

    public async Task<Result> UpdateRolesAsync(string userId, UpdateUserRolesRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = userId == currentUserId;
        if (isCurrentUser)
        {
            return Result<string>
                .Fail("Вы не можете изменить роль учётной записи самому себе!");
        }
        
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(userId));
        if (userEntity == null)
        {
            return Result<string>
                .Fail("Пользователь под данным идентификатором не найден!");
        }
        var isDefaultUser = userEntity.Username is "admin" or "journalist" or "guest";
        if (isDefaultUser)
        {
            return Result<string>
                .Fail("Изменение ролей для данному пользователю невозможно!");
        }
        var selectedRole = request.UserRoles.SingleOrDefault(x => x.Selected);
        if (selectedRole == null)
        {
            return Result<string>
                .Fail("Ни одной роли не выбрано!");
        }
        var roleEntity = await _roleRepository
            .GetByNameAsync(selectedRole.Name);
        if (roleEntity == null)
        {
            return Result<string>
                .Fail("Выбранная роль не найдена в системе!");
        }
        userEntity.RoleId = roleEntity.ID;
        userEntity.Updated = DateTime.UtcNow;
        await _userRepository.UpdateAsync(userEntity);
        return Result<string>
            .Success("Роли пользователя успешно изменены.");
    }

    public async Task<Result> ToggleStatusAsync(string userId, ToggleUserStatusRequest request)
    {
        var claims = _httpContextAccessor.HttpContext.User;
        var currentUserId = claims.GetLoggedInUserId<string>();
        var isCurrentUser = userId == currentUserId;
        if (isCurrentUser)
        {
            return Result<string>
                .Fail("Вы не можете отключить учётную запись самому себе!");
        }
        var userEntity = await _userRepository
            .GetByIdAsync(Guid.Parse(userId));
        if (userEntity == null)
        {
            return Result<string>
                .Fail("Пользователь с данным идентификатором не найден!");
        }
        userEntity.IsActive = request.ActivateUser;
        userEntity.Updated = DateTime.UtcNow;
        await _userRepository.UpdateAsync(userEntity);
        return Result<string>
            .Success("Статус учётной записи пользователя успешно изменён.");
    }
}
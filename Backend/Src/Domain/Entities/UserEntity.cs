namespace Domain.Entities;

public class UserEntity 
    : BaseEntity<Guid>
{
    public int RoleId { get; set; }

    public string ProfilePictureUrl { get; set; } = string.Empty;
    public string LastName { get; set;} = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } = string.Empty;

    public string Username { get; set;} = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public bool IsActive { get; set; }

    public RoleEntity Role { get; set; } = null!;

    public ICollection<ViewEntity> Views { get; set; } = [];
    public ICollection<SessionEntity> Sessions { get; set; } = [];
    public ICollection<NewsEntity> News { get; set; } = [];
    public ICollection<LikeEntity> Likes { get; set; } = [];
    public ICollection<CommentEntity> Comments { get; set; } = [];
    public ICollection<BookMarkEntity> BookMarks { get; set; } = [];
}
namespace Domain.Entities;

public class CommentEntity
    : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public Guid NewsId { get; set; }

    public string Content { get; set; } = string.Empty;

    public UserEntity User { get; set; } = null!;
    public NewsEntity News { get; set; } = null!;
}
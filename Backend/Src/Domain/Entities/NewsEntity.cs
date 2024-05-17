namespace Domain.Entities;

public class NewsEntity
    : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public int CategoryId { get; set; }

    public string ImageTitleUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    
    public UserEntity User { get; set; } = null!;
    public CategoryEntity Category  { get; set; } = null!;

    public ICollection<ViewEntity> Views { get; set; } = [];
    public ICollection<LikeEntity> Likes { get; set; } = [];
    public ICollection<CommentEntity> Comments { get; set; } = [];
    public ICollection<BookMarkEntity> BookMarks { get; set; } = [];
}
namespace Domain.Entities;

public class CategoryEntity
    : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<NewsEntity> News { get; set; } = [];
}
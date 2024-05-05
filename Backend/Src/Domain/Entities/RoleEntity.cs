namespace Domain.Entities;

public class RoleEntity 
    : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    
    public ICollection<UserEntity> Users { get; set; } = [];
}
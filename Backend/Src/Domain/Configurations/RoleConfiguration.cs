namespace Domain.Configurations;

public class RoleConfiguration
    : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(x => x.ID);
        
        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder.HasMany(x => x.Users)
            .WithOne(x => x.Role);

        var roles = Enum
            .GetValues<Role>()
            .Select(r => new RoleEntity
            {
                ID = (int)r,
                Name = r.ToString(),
                Created = DateTime.UtcNow
            });
        builder.HasData(roles);
    }
}
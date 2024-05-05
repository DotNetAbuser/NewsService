namespace Domain.Configurations;

public class CategoryConfiguration
    : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(x => x.ID);
        
        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasIndex(x => x.Description)
            .IsUnique();

        builder
            .HasMany(x => x.News)
            .WithOne(x => x.Category);

        var defaultCategories = new List<CategoryEntity>
        {
            new()
            {
                ID = 1,
                Name = "Политика",
                Description = "Новости о политической жизни страны",
                Created = DateTime.UtcNow
            },
            new()
            {
                ID = 2,
                Name = "Спорт",
                Description = "Новости о спорте",
                Created = DateTime.UtcNow
            },
            new()
            {
                ID = 3,
                Name = "Здоровье и медицина",
                Description = "Новости о здоровье и развитие медицины",
                Created = DateTime.UtcNow
            }
        };
        builder.HasData(defaultCategories);
    }
}
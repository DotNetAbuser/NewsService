namespace Domain.Configurations;

public class NewsConfiguration 
    : IEntityTypeConfiguration<NewsEntity>
{
    public void Configure(EntityTypeBuilder<NewsEntity> builder)
    {
        builder.HasKey(x => x.ID);
        
        builder
            .HasIndex(x => x.Title)
            .IsUnique();

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.News);
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.News)
            .HasForeignKey(x => x.CategoryId);
        builder
            .HasMany(x => x.Views)
            .WithOne(x => x.News);
        builder
            .HasMany(x => x.Likes)
            .WithOne(x => x.News);
        builder
            .HasMany(x => x.Comments)
            .WithOne(x => x.News);
        builder
            .HasMany(x => x.BookMarks)
            .WithOne(x => x.News);
    }
}
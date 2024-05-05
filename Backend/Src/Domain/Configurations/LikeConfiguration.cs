namespace Domain.Configurations;

public class LikeConfiguration
    : IEntityTypeConfiguration<LikeEntity>
{
    public void Configure(EntityTypeBuilder<LikeEntity> builder)
    {
        builder.HasKey(x => x.ID);
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.News)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.NewsId);
    }
}
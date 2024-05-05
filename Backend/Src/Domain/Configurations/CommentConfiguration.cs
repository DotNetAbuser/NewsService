namespace Domain.Configurations;

public class CommentConfiguration
    : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.HasKey(x => x.ID);
        
        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.News)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.NewsId);
    }
}
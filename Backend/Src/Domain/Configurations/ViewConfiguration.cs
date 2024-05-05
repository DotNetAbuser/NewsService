namespace Domain.Configurations;

public class ViewConfiguration
    : IEntityTypeConfiguration<ViewEntity>
{
    public void Configure(EntityTypeBuilder<ViewEntity> builder)
    {
        builder.HasKey(x => x.ID);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Views)
            .HasForeignKey(x => x.UserId);
        builder
            .HasOne(x => x.News)
            .WithMany(x => x.Views)
            .HasForeignKey(x => x.NewsId);
    }
}
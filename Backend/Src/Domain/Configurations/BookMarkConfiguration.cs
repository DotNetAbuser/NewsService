namespace Domain.Configurations;

public class BookMarkConfiguration 
    : IEntityTypeConfiguration<BookMarkEntity>
{
    public void Configure(EntityTypeBuilder<BookMarkEntity> builder)
    {
        builder.HasKey(x => x.ID);

        builder.HasOne(x => x.User)
            .WithMany(x => x.BookMarks)
            .HasForeignKey(x => x.UserId);
        
        builder.HasOne(x => x.News)
            .WithMany(x => x.BookMarks)
            .HasForeignKey(x => x.NewsId);
    }
}
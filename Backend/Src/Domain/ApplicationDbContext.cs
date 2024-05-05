namespace Domain;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<ViewEntity> Views { get; set; }
    public DbSet<BookMarkEntity> BookMarks { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }
    
    public DbSet<NewsEntity> News { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        modelBuilder.ApplyConfiguration(new BookMarkConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new LikeConfiguration());

        modelBuilder.ApplyConfiguration(new NewsConfiguration());
    }
}
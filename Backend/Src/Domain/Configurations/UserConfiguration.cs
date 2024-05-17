namespace Domain.Configurations;

public class UserConfiguration 
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.ID);
        
        builder.HasIndex(x => x.Username)
            .IsUnique();
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.HasIndex(x => x.Phone)
            .IsUnique();

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
        builder
            .HasMany(x => x.Views)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Sessions)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.News)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Likes)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.Comments)
            .WithOne(x => x.User);
        builder
            .HasMany(x => x.BookMarks)
            .WithOne(x => x.User);

        var defaultUsers = new List<UserEntity>
        {
            new()
            {
                ID = Guid.NewGuid(),
                RoleId = (int)Role.Admin,
                LastName = "Фатхудинов",
                FirstName = "Артур",
                MiddleName = "Рустамович",
                Username = "artur_admin",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("12032003"),
                Email = "admin@example.com",
                Phone = "+79177793607",
                IsActive = true,
                Created = DateTime.UtcNow
            },
            new()
            {
                ID = Guid.NewGuid(),
                RoleId = (int)Role.Redactor,
                LastName = "Фатхудинов",
                FirstName = "Артур",
                MiddleName = "Рустамович",
                Username = "artur_redactor",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("12032003"),
                Email = "redactor@example.com",
                Phone = "+79177793601",
                IsActive = true,
                Created = DateTime.UtcNow
            },
            new()
            {
                ID = Guid.NewGuid(),
                RoleId = (int)Role.Journalist,
                LastName = "Фатхудинов",
                FirstName = "Артур",
                MiddleName = "Рустамович",
                Username = "artur_journalist",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("12032003"),
                Email = "journalist@example.com",
                Phone = "+79177793608",
                IsActive = true,
                Created = DateTime.UtcNow
            },
            new()
            {
                ID = Guid.NewGuid(),
                RoleId = (int)Role.Guest,
                LastName = "Фатхудинов",
                FirstName = "Артур",
                MiddleName = "Рустамович",
                Username = "artur_guest",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("12032003"),
                Email = "guest@example.com",
                Phone = "+79177793609",
                IsActive = true,
                Created = DateTime.UtcNow
            }
        };
        builder.HasData(defaultUsers);
    }
}
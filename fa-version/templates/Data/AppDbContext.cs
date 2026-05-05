// -----------------------------------------------------------
// EF Core DbContext
// -----------------------------------------------------------

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

// -----------------------------------------------------------
// Entities
// -----------------------------------------------------------

public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    // Foreign keys
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Guid CreatedByUserId { get; set; }
    public User CreatedBy { get; set; } = null!;
}

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = [];
}

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<TaskItem> Tasks { get; set; } = [];
}

// -----------------------------------------------------------
// Entity Configurations (Fluent API)
// -----------------------------------------------------------

public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("tasks");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(2000);

        builder.HasOne(t => t.Category)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CategoryId);

        builder.HasOne(t => t.CreatedBy)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.CreatedByUserId);

        builder.HasIndex(t => t.CreatedByUserId);
        builder.HasIndex(t => t.DueDate);
    }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.Property(u => u.FullName)
            .HasMaxLength(200)
            .IsRequired();
    }
}

// -----------------------------------------------------------
// Mapping Extension
// -----------------------------------------------------------

public static class TaskMappingExtensions
{
    public static TaskResponse ToResponse(this TaskItem task) => new(
        task.Id,
        task.Title,
        task.Description,
        task.DueDate,
        task.IsCompleted,
        task.CreatedAt);
}

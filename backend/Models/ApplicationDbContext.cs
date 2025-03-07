// Data/ApplicationDbContext.cs
using backend.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<VerificationLog> VerificationLogs { get; set; }
    
// Data/ApplicationDbContext.cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Users configuration
    modelBuilder.Entity<User>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
        entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
        entity.Property(e => e.Password).IsRequired();
        entity.Property(e => e.Role).IsRequired().HasMaxLength(50);
        entity.HasMany(e => e.Documents)
              .WithOne(d => d.User)
              .HasForeignKey(d => d.UserId)
              .OnDelete(DeleteBehavior.Cascade);
    });

    // Documents configuration
    modelBuilder.Entity<Document>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
        entity.Property(e => e.FilePath).IsRequired();
        entity.Property(e => e.VerificationCode).IsRequired().HasMaxLength(50);
        entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
        entity.Property(e => e.CreatedAt).IsRequired();
        entity.HasMany(e => e.VerificationLogs)
              .WithOne(v => v.Document)
              .HasForeignKey(v => v.DocumentId)
              .OnDelete(DeleteBehavior.Cascade);
    });

    // VerificationLogs configuration
    modelBuilder.Entity<VerificationLog>(entity =>
    {
        entity.HasKey(e => e.Id);
        entity.Property(e => e.Timestamp).IsRequired();
        entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
        entity.HasOne(e => e.Verifier)
              .WithMany()
              .HasForeignKey(e => e.VerifiedBy)
              .OnDelete(DeleteBehavior.NoAction); // Key fix: No Action instead of Cascade
    });
}}
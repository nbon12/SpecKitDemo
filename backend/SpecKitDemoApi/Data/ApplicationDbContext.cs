using Microsoft.EntityFrameworkCore;
using SpecKitDemoApi.Models;

namespace SpecKitDemoApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Username)
                .HasMaxLength(255);

            // Unique constraints
            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.HasIndex(e => e.Username)
                .IsUnique()
                .HasFilter("\"Username\" IS NOT NULL");
        });
    }
}


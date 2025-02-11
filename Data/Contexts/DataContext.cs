using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Data.Contexts;

public class DataContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<StatusTypeEntity> StatusTypes { get; set; } = null!;
    public DbSet<ServiceEntity> Services { get; set; } = null!;
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<CustomerContactEntity> CustomerContacts { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<ProjectEntity> Projects { get; set; } = null!;

    /// <summary>
    /// setting relationships and foreign keys with help with entities
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 
        modelBuilder.Entity<UserEntity>()
            .HasOne(x => x.Role) // Parent
            .WithMany(x => x.Users) // Child
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CustomerContactEntity>()
            .HasOne(x => x.Customer) // Parent
            .WithMany(x => x.CustomerContacts) // Child
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ServiceEntity>()
            .HasOne(x => x.Unit) // Parent
            .WithMany(x => x.Services) // Child
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(x => x.Status)
            .WithMany(x => x.Projects)
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(x => x.User)
            .WithMany(x => x.Projects)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(x => x.Service)
            .WithMany(x => x.Projects)
            .HasForeignKey(x => x.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(x => x.Customer)
            .WithMany(x => x.Projects)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}

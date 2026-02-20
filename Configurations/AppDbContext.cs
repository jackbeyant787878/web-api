using asp.net_core_8._0_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace asp.net_core_8._0_web_api.Configurations;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置实体关系和约束
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        // 添加种子数据
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", Age = 30 },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Age = 25 }
        );
    }
}
namespace SimpleCRUD.Models;

using Microsoft.EntityFrameworkCore;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();  
    }
    
    public DbSet<User> Users { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=root");
    }
}

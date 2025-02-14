using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Context;

public class AppDbContext(DbContextOptions options):DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role  { get; set; }
    public DbSet<Product> Product  { get; set; }
    public DbSet<Order> Order  { get; set; }
    public DbSet<Offer> Offer  { get; set; }
    public DbSet<Message> Message  { get; set; }
    public DbSet<Category> Category  { get; set; }
    public DbSet<Business> Business  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

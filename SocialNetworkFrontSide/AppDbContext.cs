using Microsoft.EntityFrameworkCore;
using SocialNetworkFrontSide.Models;

namespace SocialNetworkFrontSide;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
    public DbSet<UserModel> User { get; set; }
    public DbSet<RoleModel> Role { get; set; }
}

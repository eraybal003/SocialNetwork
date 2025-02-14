using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.Configuration;

public class RoleConf : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.Id)
            .HasMaxLength(32);
        builder.Property(r => r.Name)
            .HasMaxLength(9);
        builder.HasMany(r => r.Users).WithOne(r => r.Role);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class UserConf:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id)
            .HasMaxLength(32);
        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar");
        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(16);

        builder.HasOne(u => u.Role).WithMany(u => u.Users);
        builder.HasMany(u => u.Businesses).WithOne(u => u.Owner);
        builder.HasMany(u => u.Orders).WithOne(u => u.Buyer);
        builder.HasOne(u => u.Role).WithMany(u => u.Users);
        builder.HasMany(u => u.SentMessages).WithOne(u => u.Sender);
        builder.HasMany(u => u.ReceviedMessages).WithOne(u => u.Receiver);


    }

    
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class BusinessConf : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.Property(b => b.Id)
            .HasMaxLength(32);
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(b => b.Address)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(b => b.Phone)
            .IsRequired()
            .HasMaxLength(12);

        builder.HasOne(b => b.Owner).WithMany(b => b.Businesses);
        builder.HasMany(b => b.Products).WithOne(b => b.Business);
        builder.HasMany(b => b.Offers).WithOne(b => b.Business);
    }
}

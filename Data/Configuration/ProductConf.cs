using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class ProductConf : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Id)
            .HasMaxLength(32);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("integer");
        builder.Property(p => p.Stock)
            .IsRequired()
            .HasColumnType("integer");

        builder.HasOne(p => p.CategoryName).WithMany(p => p.Products);
        builder.HasOne(P => P.Business).WithMany(p => p.Products);
        builder.HasMany(p => p.Orders).WithMany(p => p.Products);



    }
}

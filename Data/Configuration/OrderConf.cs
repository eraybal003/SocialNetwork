using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class OrderConf : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id)
                .HasMaxLength(32);
            builder.Property(o => o.Quantity)
                .IsRequired()
                .HasColumnType("integer");
            builder.Property(o => o.Status)
                .HasMaxLength(10);
            builder.HasOne(o => o.Buyer)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(o => o.Products)
                .WithMany(o => o.Orders);
            
        }
    }
}

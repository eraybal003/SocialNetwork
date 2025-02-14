using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class OfferConf : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.Property(of => of.Id)
            .HasMaxLength(32);
        builder.Property(of => of.Title)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(of => of.OfferedPrice)
            .IsRequired()
            .HasColumnType("decimal");
        builder.Property(of => of.Status)
            .HasMaxLength(12);

        builder.HasOne(of => of.Product)
            .WithMany(of => of.Offers)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(of => of.Buyer)
            .WithMany(of => of.Offers)
            .HasForeignKey(of => of.BuyerId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(of => of.Business).WithMany(of => of.Offers);

    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration;

public class MessageConf : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.Property(m => m.Id)
            .HasMaxLength(32);

        builder.Property(m => m.Content)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(m => m.Sender)
            .WithMany(m => m.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(m => m.Receiver)
            .WithMany(m => m.ReceviedMessages)
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

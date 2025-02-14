using Domain.Common;
namespace Domain.Entities;

public class Message:EntityBase
{

    public Guid SenderId { get; set; }
    public User Sender { get; set; }
    public Guid ReceiverId { get; set; }
    public User Receiver { get; set; }
    public string Content { get; set; } = string.Empty;
}

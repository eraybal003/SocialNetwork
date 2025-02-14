using Domain.Common;

namespace Domain.Entities;
public class Offer:EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid BuyerId { get; set; }
    public User Buyer { get; set; }
    public int BusinessId { get; set; }
    public Business Business { get; set; }
    public decimal OfferedPrice { get; set; }
    public string Status { get; set; } = string.Empty;
}

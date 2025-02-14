    using Domain.Common;

namespace Domain.Entities;
public class Order:EntityBase
{
    public Guid BuyerId { get; set; }
    public User Buyer { get; set; }
    public Guid ProductId { get; set; }
    public ICollection<Product> Products { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = string.Empty;
}
public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled,
    Returned
}

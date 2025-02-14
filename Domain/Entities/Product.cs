using Domain.Common;

namespace Domain.Entities;
public class Product : EntityBase 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category CategoryName { get; set; }
    public int BusinessId { get; set; }
    public Business Business { get; set; }
    public ICollection<Order> Orders { get; set; }

    public int OfferId { get; set; }
    public ICollection<Offer> Offers { get; set; }
}

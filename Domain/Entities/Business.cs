using Domain.Common;

namespace Domain.Entities;
public class Business:EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public int OwnerId { get; set; }
    public User Owner { get; set; }
    public ICollection<Offer> Offers { get; set; }
}

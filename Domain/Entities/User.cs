using Domain.Common;
namespace Domain.Entities;

public class User:EntityBase
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; }
    public string Password { get; set; } = string.Empty;
    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    public int BusinessId { get; set; }
    public ICollection<Business> Businesses { get; set; }
    public int OrderId { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Message> SentMessages { get; set; }   
    public ICollection<Message> ReceviedMessages { get; set; }

    public int OfferId { get; set; }
    public ICollection<Offer> Offers  { get; set; }


}

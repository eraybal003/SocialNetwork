using Domain.Common;
namespace Domain.Entities;

public class Role:EntityBase
{
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}

namespace SocialNetworkFrontSide.Models;

public class RoleModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public virtual  ICollection<UserModel> Users { get; set; } 
}

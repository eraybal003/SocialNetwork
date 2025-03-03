using System.ComponentModel.DataAnnotations;

namespace SocialNetworkFrontSide.Models;

public class UserModel
{
	
	public Guid Id { get; set; } 
    public string FullName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Phone { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;

    public Guid RoleId { get; set; }
	
	public virtual  ICollection<RoleModel> Roles { get; set; }

}

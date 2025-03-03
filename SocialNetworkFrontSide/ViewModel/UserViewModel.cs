using System.ComponentModel.DataAnnotations;

namespace SocialNetworkFrontSide.ViewModel;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Rol seçimi zorunludur.")]
    public Guid RoleId { get; set; }
    [Required(ErrorMessage = "At least one role is required")]
    public List<Guid> SelectedRoleIds { get; set; } = new List<Guid>();
    public string Role { get; set; } = string.Empty;
}

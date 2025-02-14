using Domain.Entities;
namespace Application.DTOs;
public record UserDTO(Guid Id, string FullName,string Email,string Phone,
    Role Role,ICollection<Business> Businesses,
    ICollection<Order> Orders,ICollection<Message> SentMessages, 
    ICollection<Message> ReceviedMessages,ICollection<Offer> Offers);
public record UserCreateDTO(string FullName,string Email,string Phone,Guid RoleId);
public record UserUpdateDTO(string FullName);
public record UserDeleteDTO(Guid Id);


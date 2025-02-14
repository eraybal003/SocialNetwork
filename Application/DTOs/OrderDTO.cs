using Domain.Entities;
using Microsoft.Identity.Client;

namespace Application.DTOs;

public record OrderDTO(Guid Id,User Buyer,ICollection<Product> Products,int Quantity
    ,decimal TotalPrice,string Status);
public record OrderCreateDTO(User Buyer,ICollection<Product> Products,decimal TotalPrice,int Quantity);  
public record OrderUpdateDTO(ICollection<Product> Products,decimal TotalPrice,int Quantity);  
public record OrderDeleteDTO(Guid Id);  


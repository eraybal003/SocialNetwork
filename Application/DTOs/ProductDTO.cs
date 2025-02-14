using Domain.Entities;

namespace Application.DTOs;

public record ProductDTO(Guid Id,string Name,string Description,decimal Price,
    int Stock,Category Category,Business Business,ICollection<Order> Orders,ICollection<Offer> Offers);
public record ProductCreateDTO(string Name,string Description,decimal Price,int Stock);
public record ProductUpdateDTO(string Name, string Description, decimal Price, int Stock);
public record ProductDeleteDTO(Guid Id);


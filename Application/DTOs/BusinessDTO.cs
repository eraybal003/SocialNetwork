using Domain.Entities;

namespace Application.DTOs;

public record BusinessDTO(Guid Id,string name,string Description,string Address,string Phone,
    ICollection<Product> Products,User Owner,ICollection<Offer> Offers);
public record BusinessCreateDTO(string name, string Description, string Address, string Phone);
public record BusinessUpdateDTO(string name, string Description, string Address, string Phone);
public record BusinessDeleteDTO(Guid Id);
using Domain.Entities;

namespace Application.DTOs;

public record CategoryDTO(Guid Id,string Name,ICollection<Product> Products);
public record CategoryCreateDTO(string Name);
public record CategoryUpdateDTO(string Name);
public record CategoryDeleteDTO(Guid Id);

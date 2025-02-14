using Domain.Entities;

namespace Application.DTOs;

public record RoleDTO(Guid Id,string Name, ICollection<User> Users);
public record RoleCreateDTO(string Name);
public record RoleUpdateDTO(string Name);
public record RoleDeleteDTO(Guid Id);



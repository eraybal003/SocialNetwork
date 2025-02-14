using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;

namespace Application.Features;

public class RoleService(IRoleRepository repository)
{
    private readonly IRoleRepository _repository = repository;

    public IEnumerable<RoleDTO> GetRoles()
    {
        List<RoleDTO> roles = [];
        foreach (Role item in _repository.GetAll())
        {
            roles.Add(new(item.Id,item.Name,item.Users));
        }
        return roles;
    }
    public RoleDTO GetRoleById(Guid Id)
    {
        var role = _repository.FindOne(r => r.Id == Id);
        if (role == null)
        {
            return new(default,string.Empty,default);
        }
        return new(role.Id, role.Name, role.Users);
    }    
    public RoleDTO GetRoleByName(string Name)
    {
        var role = _repository.FindOne(r => r.Name == Name);
        if (role == null)
        {
            return new(default,string.Empty,default);
        }
        return new(role.Id, role.Name, role.Users);
    }
    public void Add(RoleCreateDTO roleCreate)
    {
        _repository.Add(new() {
            Name = roleCreate.Name
        });
    }
    public void Update(RoleUpdateDTO roleUpdate)
    {
        _repository.Update(new()
        {
            Name = roleUpdate.Name
        });
    }
    public void Delete( RoleDeleteDTO roleDelete)
    {
        _repository.Delete(new()
        {
            Id = roleDelete.Id
        });
    }
}

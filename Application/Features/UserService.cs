using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;

namespace Application.Features;

public class UserService(IUserRepository repository)
{
    private readonly IUserRepository _repository = repository;
    public IEnumerable<UserDTO> GetUsers()
    {
        List<UserDTO> users = [];
        foreach (User item in _repository.GetAll())
        {
            users.Add(new(item.Id,item.FullName,item.Email,item.Phone,
                item.Role,item.Businesses,item.Orders,item.SentMessages,item.ReceviedMessages,item.Offers));
        }
        return users;
    }
    public UserDTO GetUserById(Guid Id)
    {
        var user = _repository.FindOne(u => u.Id == Id);
        if (user == null)
        {
            return new(default, string.Empty, string.Empty, string.Empty, 
                default, default, default, default, default, default);
        }
        return new(user.Id, user.FullName, user.Email, user.Phone,
            user.Role, user.Businesses, user.Orders, 
            user.SentMessages,user.ReceviedMessages,user.Offers);
    }    
    public UserDTO GetUserByName(string Name)
    {
        var user = _repository.FindOne(u => u.FullName == Name);
        if (user == null)
        {
            return new(default, string.Empty, string.Empty, string.Empty, 
                default, default, default, default, default, default);
        }
        return new(user.Id, user.FullName, user.Email, user.Phone,
            user.Role, user.Businesses, user.Orders, 
            user.SentMessages,user.ReceviedMessages,user.Offers);
    }
    public void Add(UserCreateDTO userCreate)
    {
        _repository.Add(new()
        {
            FullName = userCreate.FullName,
            Email = userCreate.Email,
            Phone = userCreate.Phone,
            RoleId = userCreate.RoleId
        });
    }
    public  void Update(UserUpdateDTO userUpdate)
    {
        _repository.Update(new() {
            FullName = userUpdate.FullName,
        });
    }
    public void Delete(UserDeleteDTO userDelete)
    {
        _repository.Delete(new() { Id = userDelete.Id });
    }
}

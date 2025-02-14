using Application.DTOs;
using Application.Features;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(UserService userService) : ControllerBase
{
    private readonly UserService _service = userService;

    [HttpGet]
    public ActionResult<IEnumerable<UserDTO>> Get()
    {
        return Ok(_service.GetUsers());
    }
    [HttpGet("{id}")]
    public ActionResult<UserDTO> GetById(Guid id)
    {
        var user = _service.GetUserById(id);
        if (user.Id == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpGet("{name:alpha}")]
    public ActionResult<UserDTO> GetByName(string name)
    {
        var user = _service.GetUserByName(name);
        if (user.FullName == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult Post(UserCreateDTO userCreate)
    {
        _service.Add(userCreate);
        return Ok();
    }
    [HttpPut]
    public ActionResult Put(UserUpdateDTO userUpdate)
    {
        _service.Update(userUpdate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(UserDeleteDTO userDelete)
    {
        _service.Delete(userDelete);
        return Ok();
    }
}

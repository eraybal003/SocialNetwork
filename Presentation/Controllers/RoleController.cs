using Application.DTOs;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(RoleService roleService) : ControllerBase
{
    private readonly RoleService _service = roleService;

    [HttpGet]
    public ActionResult<IEnumerable<RoleDTO>> Get()
    {
        var role = _service.GetRoles();
        return Ok(role);
    }
    [HttpGet("{id}")]
    public ActionResult<RoleDTO> GetById(Guid id)
    {
        var role = _service.GetRoleById(id);
        if (role.Id == null)
        {
            return NotFound();
        }
        return Ok(role);
    } 
    [HttpGet("{name:alpha}")]
    public ActionResult<RoleDTO> GetByName(string name)
    {
        var role = _service.GetRoleByName(name);
        if (role.Name== null)
        {
            return NotFound();
        }
        return Ok(role);
    }
    [HttpPost]
    public ActionResult Post(RoleCreateDTO roleCreate)
    {
        _service.Add(roleCreate);
        return Ok();
    }
    [HttpPatch]
    public ActionResult Patch(RoleUpdateDTO roleUpdate)
    {
        _service.Update(roleUpdate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(RoleDeleteDTO roleDelete)
    {
        _service.Delete(roleDelete);
        return Ok();
    }
}

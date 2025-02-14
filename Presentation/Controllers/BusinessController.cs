using Application.DTOs;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessController(BusinessService businessService) : ControllerBase
{
    private readonly BusinessService _service = businessService;

    [HttpGet]
    public ActionResult<IEnumerable<BusinessDTO>> GetAll()
    {
        var business = _service.GetBusinesses();
        return Ok(business);
    } 
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<BusinessDTO>> GetById(Guid id)
    {
        var business = _service.GetBusinessById(id);
        if (business.Id == null)
        {
            return NotFound();
        }
        return Ok(business);
    }
    [HttpGet("{address:alpha}")]
    public ActionResult<IEnumerable<BusinessDTO>> GetByAddress(string address)
    {
        var business = _service.GetBusinessByAddress(address);
        if (business.Address == null)
        {
            return NotFound();
        }
        return Ok(business);
    }
    [HttpPost]
    public ActionResult Post(BusinessCreateDTO businessCreate)
    {
        _service.Create(businessCreate);
        return Ok();
    }
    [HttpPatch]
    public ActionResult Patch(BusinessUpdateDTO businessUpdate)
    {
        _service.Update(businessUpdate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(BusinessDeleteDTO businessDelete)
    {
        _service.Erase(businessDelete);
        return Ok();
    }
}

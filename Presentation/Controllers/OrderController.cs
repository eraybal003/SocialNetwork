using Application.DTOs;
using Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController(OrderService orderService) : ControllerBase
{
    private readonly OrderService _service = orderService;

    [HttpGet]
    public ActionResult<IEnumerable<OrderDTO>> GetAll()
    {
        var order = _service.GetOrders();
        return Ok(order);
    } 
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<OrderDTO>> GetById(Guid id)
    {
        var order = _service.GetOrderById(id);
        if (order.Id == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
    [HttpGet("{status:alpha}")]
    public ActionResult<IEnumerable<OrderDTO>> GetByStatus(string status)
    {
        var order = _service.GetOrderByStatus(status);
        if (order.Status == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
    [HttpPost]
    public ActionResult  Post(OrderCreateDTO orderCreate)
    {
        _service.Append(orderCreate);
        return Ok();
    }
    [HttpPatch]
    public ActionResult Patch(OrderUpdateDTO orderUpdate)
    {
        _service.Updating(orderUpdate);
        return Ok(orderUpdate);
    }
    [HttpDelete]
    public ActionResult Delete(OrderDeleteDTO orderDelete)
    {
        _service.Erase(orderDelete);
        return Ok();
    }
}

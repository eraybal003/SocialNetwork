using Application.DTOs;
using Application.Features;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController(MessageService messageService) : ControllerBase
{
    private readonly MessageService Service1 = messageService;

    [HttpGet]
    public ActionResult<IEnumerable<MessageDTO>> GetAll()
    {
        var message = Service1.GetMessages();
        return Ok(message);
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<MessageDTO>> GetById(Guid id)
    {
        var message = Service1.GetMessageById(id);
        if (message.Id == null)
        {
            return NotFound();
        }
        return Ok(message);
    }    
    [HttpGet("{sender:alpha}")]
    public ActionResult<IEnumerable<MessageDTO>> GetBySender(User sender)
    {
        var message = Service1.GetMessageBySender(sender);
        if (message.Sender == null)
        {
            return NotFound();
        }
        return Ok(message);
    }
    [HttpPost]
    public ActionResult Post(MessageCreateDTO messageCreate)
    {
        Service1.Create(messageCreate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(MessageDeleteDTO messageDelete)
    {
        Service1.Erase(messageDelete);
        return Ok();
    }
}

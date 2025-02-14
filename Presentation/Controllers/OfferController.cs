using Application.DTOs;
using Application.Features;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController(OfferService offerService) : ControllerBase
{
    private readonly OfferService _service = offerService;

    [HttpGet]
    public ActionResult<IEnumerable<OfferDTO>> GetAll()
    {
        var offer = _service.GetOffers();
        return Ok(offer);
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<OfferDTO>> GetById(Guid id)
    {
        var offer = _service.GetOfferById(id);
        if (offer.Id == null)
        {
            return NotFound();
        }
        return Ok(offer);
    }
    [HttpGet("{product:alpha}")]
    public ActionResult<IEnumerable<OfferDTO>> GetByProduct(Product product)
    {
        var offer = _service.GetOfferByProduct(product);
        if (offer.Id == null)
        {
            return NotFound();
        }
        return Ok(offer);
    }
    [HttpGet("{status:alpha}")]
    public ActionResult<IEnumerable<OfferDTO>> GetByStatus(string status)
    {
        var offer = _service.GetOfferByStatus(status);
        if (offer.Status == null)
        {
            return NotFound();
        }
        return Ok(offer);
    }
    [HttpPost]
    public ActionResult Post(OfferCreateDTO offerCreate)
    {
        _service.Create(offerCreate);
        return Ok();
    }
    [HttpPatch]
    public ActionResult Patch(OfferUpdateDTO offerUpdate)
    {
        _service.Update(offerUpdate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(OfferDeleteDTO offerDelete)
    {
        _service.Erease(offerDelete);
        return Ok();
    }

}


using Application.DTOs;
using Application.Features;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductService productService) : ControllerBase
{
    private readonly ProductService _service = productService;

    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> Get()
    {
       var product =  _service.GetProducts();
        return Ok(product);
    }
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<ProductDTO>> GetById(Guid id)
    {
        var product = _service.GetProductById(id);
        if (product.Id == null)
        {
            return NotFound();
        }
        return Ok(product);
    }  
    [HttpGet("{name:alpha}")]
    public ActionResult<IEnumerable<ProductDTO>> GetByName(string name)
    {
        var product = _service.GetProductByName(name);
        if (product.Name == null)
        {
            return NotFound();
        }
        return Ok(product);
    } 
    [HttpGet("{stock:alpha}")]
    public ActionResult<IEnumerable<ProductDTO>> GetByStock(int stock)
    {
        var product = _service.GetProductByStock(stock);
        if (product.Stock == null)
        {
            return NotFound();
        }
        return Ok(product);
    } 
    [HttpGet("{category:alpha}")]
    public ActionResult<IEnumerable<ProductDTO>> GetByCategory(Category category)
    {
        var product = _service.GetProductByCategory(category);
        if (product.Category == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost]
    public ActionResult Post(ProductCreateDTO productCreate)
    {
        _service.Append(productCreate);
        return Ok();
    }
    [HttpPatch]
    public ActionResult Patch(ProductUpdateDTO productUpdate)
    {
        _service.Updating(productUpdate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(ProductDeleteDTO productDelete)
    {
        _service.Erase(productDelete);
        return Ok();
    }

}

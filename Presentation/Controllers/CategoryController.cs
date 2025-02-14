using Application.DTOs;
using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(CategoryService categoryService) : ControllerBase
{
    private readonly CategoryService _service = categoryService;

    [HttpGet] 
    public ActionResult<IEnumerable<CategoryDTO>> GetAll()
    {
        var category = _service.GetCategories();
        return Ok(category);
    }
    [HttpGet("{id}")] 
    public ActionResult<IEnumerable<CategoryDTO>> GetById(Guid id)
    {
        var category = _service.GetCategoryById(id);
        if (category.Id == null)
        {
            return NotFound();
        }
        return Ok(category);
    } 
    [HttpGet("{name:alpha}")] 
    public ActionResult<IEnumerable<CategoryDTO>> GetByName(string name)
    {
        var category = _service.GetCategoryByName(name);
        if (category.Name == null)
        {
            return NotFound();
        }
        return Ok(category);
    }
    [HttpPost]
    public ActionResult Post(CategoryCreateDTO categoryCreate)
    {
        _service.Add(categoryCreate);
        return Ok();
    }
    [HttpPatch]
    public ActionResult Patch(CategoryUpdateDTO categoryUpdate)
    {
        _service.Update(categoryUpdate);
        return Ok();
    }
    [HttpDelete]
    public ActionResult Delete(CategoryDeleteDTO categoryDelete)
    {
        _service.Delete(categoryDelete);
        return Ok();
    }

}

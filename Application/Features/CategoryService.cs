using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;
namespace Application.Features;

public class CategoryService(ICategoryRepository repository)
{
    private readonly ICategoryRepository repository1 = repository;

    public IEnumerable<CategoryDTO> GetCategories()
    {
        List<CategoryDTO> categories = [];
        foreach (Category item in repository1.GetAll())
        {
            categories.Add(new(item.Id, item.Name, item.Products));
        }
        return categories;
    }
    public CategoryDTO GetCategoryById(Guid Id)
    {
        var category = repository1.FindOne(c => c.Id == Id);
        if (category == null)
        {
            return new(default,string.Empty,default);
        }
        return new(category.Id,category.Name,category.Products);
    }
    public CategoryDTO GetCategoryByName(string Name)
    {
        var category = repository1.FindOne(c => c.Name == Name);
        if (category == null)
        {
            return new(default,string.Empty,default);
        }
        return new(category.Id,category.Name,category.Products);
    }
    public void Add(CategoryCreateDTO categoryCreate)
    {
        repository1.Add(new()
        {
            Name = categoryCreate.Name
        });

    }
    public void Update(CategoryUpdateDTO categoryUpdate)
    {
        repository1.Update(new()
        {
            Name = categoryUpdate.Name
        });
    }
    public void Delete(CategoryDeleteDTO categoryDelete)
    {
        repository1.Delete(new()
        {
            Id = categoryDelete.Id
        });
    }


    
}


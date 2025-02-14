using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;

namespace Application.Features;

public class ProductService(IProductRepository repository)
{
    private readonly IProductRepository repository1 = repository;

    public IEnumerable<ProductDTO> GetProducts()
    {
        List<ProductDTO> products = [];
        foreach (Product item in repository1.GetAll())
        {
            products.Add(new(item.Id,item.Name,item.Description,item.Price,item.Stock,
                item.CategoryName,item.Business,item.Orders,item.Offers));
        }
        return products;
    }
    public ProductDTO GetProductById(Guid id)
    {
        var product = repository1.FindOne(p => p.Id == id);
        if (product == null)
        {
            return new(default, string.Empty, string.Empty, default, default,
                default,default,default,default);
        }
        return new(product.Id, product.Name, product.Description, product.Price, product.Stock,
            product.CategoryName,product.Business,product.Orders,product.Offers);
    }
    public ProductDTO GetProductByCategory(Category category)
    {
        var product = repository1.FindOne(p => p.CategoryName == category);
        if (product == null)
        {
            return new(default, string.Empty, string.Empty, default, default,
                default,default,default,default);
        }
        return new(product.Id, product.Name, product.Description, product.Price, product.Stock,
            product.CategoryName,product.Business,product.Orders,product.Offers);
    }    
    public ProductDTO GetProductByName(string name)
    {
        var product = repository1.FindOne(p => p.Name == name);
        if (product == null)
        {
            return new(default, string.Empty, string.Empty, default, default,
                default,default,default,default);
        }
        return new(product.Id, product.Name, product.Description, product.Price, product.Stock,
            product.CategoryName,product.Business,product.Orders,product.Offers);
   }
    public ProductDTO GetProductByStock(int stock)
    {
        var product = repository1.FindOne(p => p.Stock == stock);
        if (product == null)
        {
            return new(default, string.Empty, string.Empty, default, default,
                default,default,default,default);
        }
        return new(product.Id, product.Name, product.Description, product.Price, product.Stock,
            product.CategoryName,product.Business,product.Orders,product.Offers);
   }
    public void Append(ProductCreateDTO productCreate)
    {
        repository1.Add(new() 
        {
            Name = productCreate.Name,
            Description = productCreate.Description,
            Price = productCreate.Price,
            Stock = productCreate.Stock
        });
    }
    public void Updating(ProductUpdateDTO updateDTO)
    {
        repository1.Update(new()
        {
            Name = updateDTO.Name,
            Description = updateDTO.Description,
            Price = updateDTO.Price,
            Stock = updateDTO.Stock

        });
    }
    public void Erase(ProductDeleteDTO productDelete)
    {
        repository1.Delete(new() { Id = productDelete.Id});
    }

}

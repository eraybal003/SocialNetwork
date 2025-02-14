using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;

namespace Application.Features;

public class BusinessService(IBusinessRepository businessRepository)
{
    private readonly IBusinessRepository _repository = businessRepository;

    public IEnumerable<BusinessDTO> GetBusinesses()
    {
        List<BusinessDTO> businesses = [];
        foreach (var item in _repository.GetAll())
        {
            businesses.Add(new(item.Id,item.Name,item.Description,item.Address,item.Phone,
                item.Products,item.Owner,item.Offers));
        }
        return businesses;
    }
    public BusinessDTO GetBusinessById(Guid id)
    {
        var business = _repository.FindOne(b => b.Id == id);
        if (business == null)
        {
            return new(default,string.Empty,string.Empty,string.Empty,string.Empty,
                default,default,default);
        }
        return new(business.Id,business.Name,business.Description,business.Address,business.Phone,
            business.Products,business.Owner,business.Offers);
    } 
    public BusinessDTO GetBusinessByAddress(string address)
    {
        var business = _repository.FindOne(b => b.Address == address);
        if (business == null)
        {
            return new(default,string.Empty,string.Empty,string.Empty,string.Empty,
                default,default,default);
        }
        return new(business.Id,business.Name,business.Description,business.Address,business.Phone,
            business.Products,business.Owner,business.Offers);
    } 
    public BusinessDTO GetBusinessByOffer(Offer offer)
    {
        var business = _repository.FindOne(b => b.Offers == offer);
        if (business == null)
        {
            return new(default,string.Empty,string.Empty,string.Empty,string.Empty,
                default,default,default);
        }
        return new(business.Id,business.Name,business.Description,business.Address,business.Phone,
            business.Products,business.Owner,business.Offers);
    }
    public void Create(BusinessCreateDTO businessCreate)
    {
        _repository.Add(new()
        {
            Name = businessCreate.name,
            Description = businessCreate.Description,
            Address = businessCreate.Address,
            Phone = businessCreate.Phone

        });
    }    
    public void Update(BusinessUpdateDTO businessUpdate)
    {
        _repository.Update(new()
        {
            Name = businessUpdate.name,
            Description = businessUpdate.Description,
            Address = businessUpdate.Address,
            Phone = businessUpdate.Phone

        });
    }
    public void Erase(BusinessDeleteDTO businessDelete)
    {
        _repository.Delete(new() { Id = businessDelete.Id});
    }

}

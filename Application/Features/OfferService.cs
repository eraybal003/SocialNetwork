using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;
namespace Application.Features;

public class OfferService(IOfferRepository offerRepository)
{
    private readonly IOfferRepository _repository = offerRepository;

    public IEnumerable<OfferDTO> GetOffers()
    {
        List<OfferDTO> offers = [];
        foreach (Offer item in _repository.GetAll())
        {
            offers.Add(new(item.Id,item.Title,item.Description,
                item.Product,item.Buyer,item.Business,item.OfferedPrice,item.Status));
        }
        return offers;
    }
    public OfferDTO GetOfferById(Guid id)
    {
        var offer = _repository.FindOne(o => o.Id == id);
        if (offer == null)
        {
            return new(default,string.Empty,string.Empty,default,default,default,default,default);
        }
        return new(offer.Id,offer.Title,offer.Description,
            offer.Product,offer.Buyer,offer.Business,offer.OfferedPrice,offer.Status);
    }
    public OfferDTO GetOfferByProduct(Product product)
    {
        var offer = _repository.FindOne(o => o.Product == product);
        if (offer == null)
        {
            return new(default,string.Empty,string.Empty,default,default,default,default,default);
        }
        return new(offer.Id,offer.Title,offer.Description,
            offer.Product,offer.Buyer,offer.Business,offer.OfferedPrice,offer.Status);
    }
    public OfferDTO GetOfferByStatus(string status)
    {
        var offer = _repository.FindOne(o => o.Status == status);
        if (offer == null)
        {
            return new(default, string.Empty, string.Empty, default, default, default, default, default);
        }
        return new(offer.Id, offer.Title, offer.Description,
            offer.Product, offer.Buyer, offer.Business, offer.OfferedPrice, offer.Status);
    }
    public void Create(OfferCreateDTO offerCreate)
    {
        _repository.Add(new()
        {
            Title = offerCreate.Title,
            Description = offerCreate.Description,
            OfferedPrice = offerCreate.OfferedPrice
        });
    }
    public void Update(OfferUpdateDTO offerUpdate)
    {
        _repository.Update(new() { OfferedPrice = offerUpdate.OfferedPrice});
    }
    public void Erease(OfferDeleteDTO offerDelete)
    {
        _repository.Delete(new() { Id = offerDelete.Id});
    }
}

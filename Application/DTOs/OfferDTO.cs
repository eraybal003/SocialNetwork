using Domain.Entities;

namespace Application.DTOs;

public record OfferDTO(Guid Id,string Title,string Description
    ,Product Product,User Buyer,Business Business,decimal OfferedPrice,string Status);
public record OfferCreateDTO(string Title,string Description,decimal OfferedPrice);
public record OfferUpdateDTO(decimal OfferedPrice);
public record OfferDeleteDTO(Guid Id);

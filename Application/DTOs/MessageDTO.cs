using Domain.Entities;

namespace Application.DTOs;

public record MessageDTO(Guid Id,User Sender,User Receiver,string Content);
public record MessageCreateDTO(User Receiver,string Content);
public record MessageDeleteDTO(Guid Id);

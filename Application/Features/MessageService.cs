using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;

namespace Application.Features;

public class MessageService(IMessageRepository messageRepository)
{
    private readonly IMessageRepository _repository = messageRepository;

    public IEnumerable<MessageDTO> GetMessages()
    {
        List<MessageDTO> messages = [];
        foreach (Message item in _repository.GetAll())
        {
            messages.Add(new(item.Id,item.Sender,item.Receiver,item.Content));   
        }
        return messages;
    }
    public MessageDTO GetMessageById(Guid id)
    {
        var message = _repository.FindOne(m => m.Id == id);
        if (message == null)
        {
            return new(default,default,default,string.Empty);
        }
        return new(message.Id,message.Sender,message.Receiver,message.Content);
    } 
    public MessageDTO GetMessageBySender(User sender)
    {
        var message = _repository.FindOne(m => m.Sender == sender);
        if (message == null)
        {
            return new(default,default,default,string.Empty);
        }
        return new(message.Id,message.Sender,message.Receiver,message.Content);
    }
    public void Create(MessageCreateDTO messageCreate)
    {
        _repository.Add(new()
        {
            Receiver = messageCreate.Receiver,
            Content = messageCreate.Content
        });
    }
    public void Erase(MessageDeleteDTO messageDelete)
    {
        _repository.Delete(new()
        {
            Id = messageDelete.Id
        });
    }
}

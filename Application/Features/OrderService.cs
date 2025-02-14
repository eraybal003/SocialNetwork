using Application.DTOs;
using Data.IRepositories;
using Domain.Entities;

namespace Application.Features;

public class OrderService(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _repository = orderRepository;

    public IEnumerable<OrderDTO> GetOrders()
    {
        List<OrderDTO> orders = [];
        foreach (Order item in _repository.GetAll())
        {
            orders.Add(new(item.Id,item.Buyer,item.Products,item.Quantity,item.TotalPrice,item.Status));
        }
        return orders;
    }
    public OrderDTO GetOrderById(Guid id)
    {
        var order = _repository.FindOne(o => o.Id == id);
        if (order == null)
        {
            return new(default,default,default,default,default,string.Empty);
        }
        return new(order.Id, order.Buyer, order.Products, order.Quantity, order.TotalPrice, order.Status);
    }    
    public OrderDTO GetOrderByStatus(string status)
    {
        var order = _repository.FindOne(o => o.Status == status);
        if (order == null)
        {
            return new(default,default,default,default,default,string.Empty);
        }
        return new(order.Id, order.Buyer, order.Products, order.Quantity, order.TotalPrice, order.Status);
    }
    public void Append(OrderCreateDTO orderCreate)
    {
        _repository.Add(new()
        {
            Buyer = orderCreate.Buyer,
            Products = orderCreate.Products,
            TotalPrice = orderCreate.TotalPrice,
            Quantity = orderCreate.Quantity
        });
    }
    public void Updating(OrderUpdateDTO orderUpdate)
    {
        _repository.Update(new()
        {
            Products = orderUpdate.Products,
            TotalPrice = orderUpdate.TotalPrice,
            Quantity = orderUpdate.Quantity
        });
    }
    public void Erase(OrderDeleteDTO orderDelete)
    {
        _repository.Delete(new()
        {
            Id = orderDelete.Id
        });
    }
}

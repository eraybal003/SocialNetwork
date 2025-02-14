using Application.Features;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection descriptors)
    {
        descriptors.AddScoped<UserService, UserService>();
        descriptors.AddScoped<RoleService, RoleService>();
        descriptors.AddScoped<ProductService, ProductService>();
        descriptors.AddScoped<CategoryService, CategoryService>();
        descriptors.AddScoped<BusinessService, BusinessService>();
        descriptors.AddScoped<OrderService, OrderService>();
        descriptors.AddScoped<OfferService, OfferService>();
        descriptors.AddScoped<MessageService, MessageService>();

        return descriptors;
    }
}

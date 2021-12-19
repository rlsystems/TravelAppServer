using ServerApp.Domain.Common.Contracts;

namespace ServerApp.Domain.Catalog.Events;

public class ProductCreatedEvent : DomainEvent
{
    public ProductCreatedEvent(Product product)
    {
        Product = product;
    }

    public Product Product { get; }
}
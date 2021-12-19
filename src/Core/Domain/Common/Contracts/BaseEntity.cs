using MassTransit;

namespace ServerApp.Domain.Common.Contracts;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public List<DomainEvent> DomainEvents = new();

    protected BaseEntity()
    {
        Id = NewId.Next().ToGuid();
    }
}
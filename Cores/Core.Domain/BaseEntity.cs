using Core.Domain.Contracts;
using Core.Domain.Events;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain;

public abstract class BaseEntity<TId> : IEntity<TId>
{
    [NotMapped]
    public Collection<DomainEvent> DomainEvents { get; } = [];

    public TId Id { get; protected set; } = default!;

    public void QueueDomainEvent(DomainEvent domainEvent)
    {
        if (!DomainEvents.Contains(domainEvent))
        {
            DomainEvents.Add(domainEvent);
        }
    }
}

public abstract class BaseEntity : BaseEntity<Guid>
{
    protected BaseEntity()
    {
        Id = Guid.CreateVersion7();
    }
}
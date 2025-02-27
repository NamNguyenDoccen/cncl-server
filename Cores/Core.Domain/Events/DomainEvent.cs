using MediatR;

namespace Core.Domain.Events;

public abstract class DomainEvent : IDomainEvent, INotification
{
    public DateTimeOffset OccurredOn { get; protected set; } = DateTimeOffset.UtcNow;
}
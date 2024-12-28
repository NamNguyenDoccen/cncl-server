using MassTransit;

namespace Core.Domain;

public abstract class BaseEntity<T>
{
    public T Id { get; set; } = default!;
}

public abstract class BaseEntity : BaseEntity<Guid>
{
    protected BaseEntity()
    {
        Id = Id == default ? NewId.NextSequentialGuid() : Id;
    }
}
﻿using Core.Domain.Contracts;

namespace Core.Domain;

public class AuditableEntity<TId> : BaseEntity<TId>, IAuditable, ISoftDelete
{
    public DateTimeOffset Created { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset? Deleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public Guid? LastModifiedBy { get; set; }
}

public abstract class AuditableEntity : AuditableEntity<Guid>
{
    protected AuditableEntity()
    {
        Id = Guid.CreateVersion7();
    }
}
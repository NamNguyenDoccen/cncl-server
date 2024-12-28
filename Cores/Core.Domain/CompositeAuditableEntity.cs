namespace Core.Domain;

public abstract class CompositeAuditableEntity : IAuditableEntity
{
    protected CompositeAuditableEntity()
    {
        CreatedOn = DateTime.UtcNow;
        LastModifiedOn = DateTime.UtcNow;
    }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}
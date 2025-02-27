namespace Core.Domain;

public interface ISoftDelete
{
    DateTimeOffset? Deleted { get; set; }
    Guid? DeletedBy { get; set; }
}
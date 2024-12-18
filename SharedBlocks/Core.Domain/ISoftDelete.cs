namespace Core.Domain;

public class ISoftDelete
{
    Guid? DeletedBy { get; set; }
    DateTime? DeletedOn { get; set; }
}
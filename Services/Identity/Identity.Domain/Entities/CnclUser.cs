using Core.Domain;
using Core.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public class CnclUser : IdentityUser<Guid>, IAuditable, ISoftDelete
{
    public CnclUser()
    {
        Id = Guid.CreateVersion7();
        SecurityStamp = Guid.CreateVersion7().ToString();
    }

    public DateTimeOffset Created { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset? Deleted { get; set; }
    public Guid? DeletedBy { get; set; }
    public string? FirstName { get; set; }
    public Uri? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset? LastModified { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public string? LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
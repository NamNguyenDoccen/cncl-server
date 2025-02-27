using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public class CnclRole : IdentityRole<Guid>
{
    public CnclRole(string name, string? description) : base(name)
    {
        Description = description;
        NormalizedName = name.ToUpperInvariant();
    }

    public string? Description { get; set; }
}
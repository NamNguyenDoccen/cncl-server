using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Entities;

public class CnclRoleClaim : IdentityRoleClaim<Guid>
{
    public string? CreatedBy { get; init; }
    public DateTimeOffset? CreatedOn { get; init; }
}
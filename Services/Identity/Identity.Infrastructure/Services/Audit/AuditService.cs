using Core.Audit;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Services.Audit;

public class AuditService(IdentityDbContext context) : IAuditService
{
    public async Task<List<AuditTrail>> GetUserTrailsAsync(Guid userId)
    {
        var trails = await context.AuditTrails
           .Where(a => a.UserId == userId)
           .OrderByDescending(a => a.DateTime)
           .Take(250)
           .ToListAsync();

        return trails;
    }
}
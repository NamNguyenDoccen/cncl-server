﻿namespace Core.Audit;

public interface IAuditService
{
    Task<List<AuditTrail>> GetUserTrailsAsync(Guid userId);
}
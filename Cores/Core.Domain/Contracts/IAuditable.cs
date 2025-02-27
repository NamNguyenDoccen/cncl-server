﻿namespace Core.Domain.Contracts;

public interface IAuditable
{
    DateTimeOffset Created { get; set; }
    Guid CreatedBy { get; set; }
    DateTimeOffset? LastModified { get; set; }
    Guid? LastModifiedBy { get; set; }
}
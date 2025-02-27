﻿using System.ComponentModel.DataAnnotations;

namespace Core.Persistence;

public class DatabaseOptions : IValidatableObject
{
    public string ConnectionString { get; set; } = string.Empty;
    public string Provider { get; set; } = "postgresql";

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            yield return new ValidationResult("Connection string is required", [nameof(ConnectionString)]);
        }
    }
}
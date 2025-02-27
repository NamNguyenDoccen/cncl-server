﻿using Identity.Domain.ValueObjects;
using System.Security.Claims;

namespace Identity.Application.Common.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string? GetEmail(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.Email);

    public static DateTimeOffset GetExpiration(this ClaimsPrincipal principal) =>
        DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(
            principal.FindFirstValue(CnclClaims.Expiration)));

    public static string? GetFirstName(this ClaimsPrincipal principal) => principal?.FindFirst(ClaimTypes.Name)?.Value;

    public static string? GetFullName(this ClaimsPrincipal principal) => principal?.FindFirst(CnclClaims.Fullname)?.Value;

    public static Uri? GetImageUrl(this ClaimsPrincipal principal)
    {
        var imageUrl = principal.FindFirstValue(CnclClaims.ImageUrl);
        return Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri) ? uri : null;
    }

    public static string? GetPhoneNumber(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.MobilePhone);

    public static string? GetSurname(this ClaimsPrincipal principal) => principal?.FindFirst(ClaimTypes.Surname)?.Value;

    public static string? GetUserId(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.NameIdentifier);

    private static string? FindFirstValue(this ClaimsPrincipal principal, string claimType) =>
        principal is null
            ? throw new ArgumentNullException(nameof(principal))
            : principal.FindFirst(claimType)?.Value;
}
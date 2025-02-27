using Core.Persistence;
using Identity.Application.Common.Constants;
using Identity.Domain.Entities;
using Identity.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence;

public class IdentityDbInitializer(
    IdentityDbContext context,
    RoleManager<CnclRole> roleManager,
    UserManager<CnclUser> userManager,
    TimeProvider timeProvider) : IDbInitializer
{
    public async Task MigrateAsync(CancellationToken ct)
    {
        if ((await context.Database.GetPendingMigrationsAsync(ct).ConfigureAwait(false)).Any())
        {
            await context.Database.MigrateAsync(ct).ConfigureAwait(false);
            //logger.LogInformation("[{Tenant}] applied database migrations for identity module", context.TenantInfo?.Identifier);
        }
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        await SeedRolesAsync();
        await SeedAdminUserAsync();
    }

    private async Task AssignPermissionsToRoleAsync(IdentityDbContext dbContext, IReadOnlyList<CnclPermission> permissions, CnclRole role)
    {
        var currentClaims = await roleManager.GetClaimsAsync(role);
        var newClaims = permissions
            .Where(permission => !currentClaims.Any(c => c.Type == CnclClaims.Permission && c.Value == permission.Name))
            .Select(permission => new CnclRoleClaim
            {
                RoleId = role.Id,
                ClaimType = CnclClaims.Permission,
                ClaimValue = permission.Name,
                CreatedBy = "application",
                CreatedOn = timeProvider.GetUtcNow()
            })
            .ToList();

        foreach (var claim in newClaims)
        {
            //logger.LogInformation("Seeding {Role} Permission '{Permission}' for '{TenantId}' Tenant.", role.Name, claim.ClaimValue, multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            await dbContext.RoleClaims.AddAsync(claim);
        }

        // Save changes to the database context
        if (newClaims.Count != 0)
        {
            await dbContext.SaveChangesAsync();
        }
    }

    private async Task SeedAdminUserAsync()
    {
        if (await userManager.Users.FirstOrDefaultAsync(u => u.Email == TenantConstants.Root.EmailAddress) is not CnclUser adminUser)
        {
            string adminUserName = $"{TenantConstants.Root.Id.Trim()}.{CnclRoles.Admin}".ToUpperInvariant();
            adminUser = new CnclUser
            {
                FirstName = TenantConstants.Root.Id.Trim().ToUpperInvariant(),
                LastName = CnclRoles.Admin,
                Email = TenantConstants.Root.EmailAddress,
                UserName = adminUserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedEmail = TenantConstants.Root.EmailAddress.ToUpperInvariant(),
                NormalizedUserName = adminUserName.ToUpperInvariant(),
                IsActive = true
            };

            //logger.LogInformation("Seeding Default Admin User for '{TenantId}' Tenant.", multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            var password = new PasswordHasher<CnclUser>();
            adminUser.PasswordHash = password.HashPassword(adminUser, TenantConstants.DefaultPassword);
            await userManager.CreateAsync(adminUser);
        }

        // Assign role to user
        if (!await userManager.IsInRoleAsync(adminUser, CnclRoles.Admin))
        {
            //logger.LogInformation("Assigning Admin Role to Admin User for '{TenantId}' Tenant.", multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id);
            await userManager.AddToRoleAsync(adminUser, CnclRoles.Admin);
        }
    }

    private async Task SeedRolesAsync()
    {
        foreach (string roleName in CnclRoles.DefaultRoles)
        {
            if (await roleManager.Roles.SingleOrDefaultAsync(r => r.Name == roleName)
                is not CnclRole role)
            {
                // create role
                role = new CnclRole(roleName, $"{roleName} Role");
                await roleManager.CreateAsync(role);
            }

            // Assign permissions
            if (roleName == CnclRoles.Basic)
            {
                await AssignPermissionsToRoleAsync(context, CnclPermissions.Basic, role);
            }
            else if (roleName == CnclRoles.Admin)
            {
                await AssignPermissionsToRoleAsync(context, CnclPermissions.Admin, role);
                await AssignPermissionsToRoleAsync(context, CnclPermissions.Root, role);
                //if (multiTenantContextAccessor.MultiTenantContext.TenantInfo?.Id == TenantConstants.Root.Id)
                //{
                //    await AssignPermissionsToRoleAsync(context, CnclPermissions.Root, role);
                //}
            }
        }
    }
}
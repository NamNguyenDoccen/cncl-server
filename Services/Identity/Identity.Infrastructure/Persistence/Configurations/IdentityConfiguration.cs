using Core.Audit;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IdentityConstants = Identity.Application.Common.Constants.IdentityConstants;

namespace Identity.Infrastructure.Persistence.Configurations;

public class AppRoleClaimConfig : IEntityTypeConfiguration<CnclRoleClaim>
{
    public void Configure(EntityTypeBuilder<CnclRoleClaim> builder)
    {
        builder.ToTable("RoleClaims", IdentityConstants.SchemaName);
    }
}

public class AppRoleConfig : IEntityTypeConfiguration<CnclRole>
{
    public void Configure(EntityTypeBuilder<CnclRole> builder)
    {
        builder.ToTable("Roles", IdentityConstants.SchemaName);
    }
}

public class AppUserConfig : IEntityTypeConfiguration<CnclUser>
{
    public void Configure(EntityTypeBuilder<CnclUser> builder)
    {
        builder.ToTable("Users", IdentityConstants.SchemaName);
    }
}

public class AuditTrailConfig : IEntityTypeConfiguration<AuditTrail>
{
    public void Configure(EntityTypeBuilder<AuditTrail> builder)
    {
        builder.ToTable("AuditTrails", IdentityConstants.SchemaName);
        builder.HasKey(x => x.Id);
    }
}

public class IdentityUserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
    {
        builder.ToTable("UserClaims", IdentityConstants.SchemaName);
    }
}

public class IdentityUserLoginConfig : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> builder)
    {
        builder.ToTable("UserLogins", IdentityConstants.SchemaName);
    }
}

public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.ToTable("UserRoles", IdentityConstants.SchemaName);
    }
}

public class IdentityUserTokenConfig : IEntityTypeConfiguration<IdentityUserToken<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> builder)
    {
        builder.ToTable("UserTokens", IdentityConstants.SchemaName);
    }
}
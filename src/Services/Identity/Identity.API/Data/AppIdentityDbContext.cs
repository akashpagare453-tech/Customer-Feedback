using Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Identity.API.Data;

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed Roles
        var adminRoleId = Guid.NewGuid().ToString();
        var memberRoleId = Guid.NewGuid().ToString();
        var managerRoleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = memberRoleId, Name = "Customer", NormalizedName = "CUSTOMER" },
            new IdentityRole { Id = managerRoleId, Name = "Manager", NormalizedName = "MANAGER" }
        );

        // Seed User
        var adminUserId = Guid.NewGuid().ToString();
        var managerUserId = Guid.NewGuid().ToString();
        var hasher = new PasswordHasher<ApplicationUser>();

        var adminUser = new ApplicationUser
        {
            Id = adminUserId,
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "YourTemporaryPassword123!"), // Set a secure temporary password
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        var managerUser = new ApplicationUser
        {
            Id = managerUserId,
            UserName = "manager@example.com",
            NormalizedUserName = "MANAGER@EXAMPLE.COM",
            Email = "manager@example.com",
            NormalizedEmail = "MANAGER@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "YourTemporaryPassword123!"), // Set a secure temporary password
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };

        builder.Entity<ApplicationUser>().HasData(adminUser, managerUser);

        // Assign Users to Roles
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            },
            new IdentityUserRole<string>
            {
                RoleId = managerRoleId,
                UserId = managerUserId
            }
        );
    }
}

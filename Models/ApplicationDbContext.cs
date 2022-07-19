using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedRoles(builder);
    }

    /// <summary>
    /// Create default roles.
    /// </summary>
    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationUserRoles.ADMIN,
                NormalizedName = ApplicationUserRoles.ADMIN.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationUserRoles.STAFF,
                NormalizedName = ApplicationUserRoles.STAFF.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = ApplicationUserRoles.CUSTOMER,
                NormalizedName = ApplicationUserRoles.CUSTOMER.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
        );
    }
}
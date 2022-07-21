using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<CustomerDetails>? CustomersDetails { get; set; }
    public DbSet<AccountType>? AccountTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        this.SeedRoles(builder);
        this.SeedAccountTypes(builder);
    }

    /// <summary>
    /// Create Customer Account Types
    /// </summary>
    private void SeedAccountTypes(ModelBuilder builder)
    {
        builder.Entity<AccountType>().HasData(
            new AccountType()
            {
                Name = "Pay As You Go",
                Description = "Pay for each rental before collection."
            },
            new AccountType()
            {
                Name = "Monthly",
                Description = "Pay for rentals at the end of each month."
            },
            new AccountType()
            {
                Name = "Quarterly",
                Description = "Pay for rentals every 3 months."
            },
            new AccountType()
            {
                Name = "Yearly",
                Description = "Pay for rental at the end of the year."
            }

        );
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
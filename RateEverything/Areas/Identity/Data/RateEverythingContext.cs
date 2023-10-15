using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateEverything.Areas.Identity.Data;
using RateEverything.Models;

namespace RateEverything.Data;

public class RateEverythingContext : IdentityDbContext<RateEverythingUser>
{
    public RateEverythingContext(DbContextOptions<RateEverythingContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Item> Items { get; set; }

    public DbSet<ItemRating> ItemRatings { get; set; }

    public DbSet<ItemComment> ItemComments { get; set; }
}

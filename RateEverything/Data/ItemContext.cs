using RateEverything.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace RateEverything.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemRating> ItemRatings { get; set; }

        public DbSet<ItemComment> ItemComments { get; set; }
    }
}

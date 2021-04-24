using Untouchable.Snow.Domain.Catalog;
using Untouchable.Snow.Domain.Order;
using Microsoft.EntityFrameworkCore;

namespace Untouchable.Snow.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}